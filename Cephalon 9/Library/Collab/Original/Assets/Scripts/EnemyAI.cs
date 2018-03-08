using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private bool dirLeft;

    private Transform enemy;

    private Rigidbody2D r2D;

    private Animator myAnimator;

    public bool Attack { get; set; }

    // Use this for initialization
    void Start ()
    {
        dirLeft = true;
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void Flip(float horizontal)
    {
        if (horizontal < 0 && dirLeft || horizontal > 0 && !dirLeft)
        {
            ChangeDirection();
        }
    }

    public void ChangeDirection()
    {
        dirLeft = !dirLeft;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
    }
}
