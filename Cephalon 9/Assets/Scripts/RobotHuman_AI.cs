using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHuman_AI : MonoBehaviour
{
	private bool isMoving = false;
	public bool dirLeft = true;
	public float turnTime = 3.0f;
	private Rigidbody2D enemyRigidbody;
	private Animator myAnimator;

	void Start()
	{
		enemyRigidbody = this.GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Vector2 v = enemyRigidbody.velocity;
		if (dirLeft)
		{
			v.x = -1.50f;
		}
		else
		{
			v.x = 1.50f;
		}

		enemyRigidbody.velocity = v;

		if (!isMoving)
		{ StartCoroutine(Move()); }

	}

	IEnumerator Move()
	{
		isMoving = true;

		yield return new WaitForSeconds(turnTime);

		if (dirLeft)
		{ dirLeft = false; }
		else
		{ dirLeft = true; }

		isMoving = false;
	}
}
