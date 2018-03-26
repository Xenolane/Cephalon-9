using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    /*
	 FOR THE MOVEMENT TO WORK THERE MUST BE AN OBJECT AS THE FIRST
	 CHILD OF THE AI THAT CONTAINS TO GAMEOBJECTS THAT INDICATE THE
	 BOUNDS OF THE MOVEMENT
	 */

    private Transform BoundsTR;
    private LayerMask mask; // To ignore itself
    private float boundsStart;
    private float boundsEnd;

    public bool wanderAround;
    [HideInInspector]
    public bool hasBoth;

    [HideInInspector]
    public float speed = 1f;
    public enum Direction { NONE, LEFT, RIGHT };
    [HideInInspector]
    public Direction dir = Direction.NONE;
    [HideInInspector]
    public bool detectedPlayer; // meant to indicate when the robot has locked the player;

    public enum Range { CLOSE, MEDIUM, FAR };
    [HideInInspector]
    public Range range = Range.MEDIUM;

    private Meelee meelee;


    private void Start()
    {
        BoundsTR = transform.GetChild(0);
        boundsStart = BoundsTR.GetChild(0).transform.position.x;
        boundsEnd = BoundsTR.GetChild(1).transform.position.x;
        ChangeDirection(Direction.RIGHT);

        hasBoth = GetComponent<Meelee>() && GetComponent<Ranged>();

		if (GetComponent<Meelee> ())
            meelee = GetComponent<Meelee>();

        mask = ~(1 << LayerMask.NameToLayer("EnemyLayer"));
    }

    private void Update()
    {
        DetectPlayer();
        CalculateRange();
        // Wander around
        if (!detectedPlayer)
        {
            if (wanderAround)
                Wander();
        }
    }

    public void ChangeDirection(Direction _dir)
    {
        dir = _dir;
        if (dir == Direction.LEFT)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        else if (dir == Direction.RIGHT)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
    }

    private void DetectPlayer()
    {
        if (detectedPlayer) // no need to do anything if the player is already detected
        {
            if (!insideMovementBounds(PlayerStats.Instance.transform))
                detectedPlayer = false;
            return;
        }

		RaycastHit2D hit = Physics2D.CircleCast((Vector2)transform.position,transform.localScale.x,(Vector2)transform.right,Mathf.Infinity,mask);

        if (hit.collider != null)
        {
			if (hit.collider.CompareTag("Player"))
            {
                if (insideMovementBounds(hit.transform))
                {
                    detectedPlayer = true;
                }
                else
                    detectedPlayer = false;
            }
            else
                detectedPlayer = false;
        }
    }

    private void CalculateRange()
    {
        if (!detectedPlayer)
            return;

        float distanceX = Mathf.Abs(transform.position.x - PlayerStats.Instance.transform.position.x);
        if (distanceX < 1.2f)
            range = Range.CLOSE;
        else if (distanceX < 3f)
            range = Range.MEDIUM;
        else
            range = Range.FAR;

		Debug.Log (range);
    }

    // Moves an object within bounds
    private void Wander()
    {
        if (dir == Direction.NONE)
            return;

        if (detectedPlayer)
            return;

        // Change direction
        if (dir == Direction.LEFT)
        {
            if (transform.position.x < boundsStart)
                ChangeDirection(Direction.RIGHT);
        }
        else if (dir == Direction.RIGHT)
        {
            if (transform.position.x > boundsEnd)
                ChangeDirection(Direction.LEFT);
        }

        // Make the movement
        float movementX = dir == Direction.LEFT ? -1f : 1f; // Determine whether to turn left or right
        transform.position += new Vector3(movementX, 0, 0) * speed * Time.deltaTime;
    }

    public void ChasePlayer()
    {
        // Chase the player
        float offsetX = transform.position.x - PlayerStats.Instance.transform.position.x;
        if (offsetX > meelee.range)
        {
            if (dir != EnemyAI.Direction.LEFT)
                ChangeDirection(EnemyAI.Direction.LEFT);
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }
        else if (offsetX < -meelee.range)
        {
            if (dir != EnemyAI.Direction.RIGHT)
                ChangeDirection(EnemyAI.Direction.RIGHT);
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }
    }

    private bool insideMovementBounds(Transform tr)
    {
        if (tr.position.x + tr.GetComponent<SpriteRenderer>().bounds.size.x / 2f > boundsStart && tr.position.x - tr.GetComponent<SpriteRenderer>().bounds.size.x / 2f < boundsEnd)
            return true;
        else
            return false;
    }

}
