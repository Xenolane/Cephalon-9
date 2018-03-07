using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jetpack : MonoBehaviour
{

	public Slider JetpackBar;
	private Rigidbody2D rb;
	private bool pressing = false;
	private Vector2 force = new Vector2(0f, 100f);
	private float maxVerticalSpeed = 7f;

	private float maxJetpackTime = 1f;
	private float jetpackTimeCounter = 0f;
    private bool isUsingJetPack = false;
    private bool jetpacking = false;
    private bool isWalking = false;
    private bool isCwalking = false;
    private bool grounded = false;
    private Animator animator;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Debug.Log(jetpackTimeCounter);
		if (Input.GetKey(KeyCode.LeftControl))
		{
            pressing = true;
            jetpacking = true;
        }
		else
		{
            jetpacking = false;
            pressing = false;
        }

		if (pressing)
		{
			if (jetpackTimeCounter < maxJetpackTime)
			{
				jetpackTimeCounter += Time.deltaTime;
				if (rb.velocity.y < maxVerticalSpeed)
					rb.velocity += new Vector2(0, 75f) * Time.deltaTime;
				else
					rb.velocity = new Vector2(0f, maxVerticalSpeed);
			}
		}
		else
		{
			if (jetpackTimeCounter > 0f)
			{
				jetpackTimeCounter -= Time.deltaTime;
			}
			else
				jetpackTimeCounter = 0f;
		}

		JetpackBar.value = 1 - jetpackTimeCounter / maxJetpackTime;

        animator.SetBool("isUsingJetPack", jetpacking);

    }

}
