using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cephalon9;

namespace Cephalon9{
	public class Jetpack : MonoBehaviour
	{
		[Header("Components")]
		[SerializeField]private Slider JetpackBar;
		[SerializeField]private Animator animator;
		private Rigidbody2D rb;

		[Header("Properties")]
		[SerializeField]private Vector2 force = new Vector2(0f, 100f);
		private float maxVerticalSpeed = 3f;

		[SerializeField]private float maxFuel=100f;
		private float fuelMultiplier = 1f;
		private float fuel;
		[SerializeField]private float consumptionRate=10f;
	    private bool jetpacking = false;
		private PlayerController plr;

	    private void Start()
		{
			rb = GetComponent<Rigidbody2D>();
			fuel = maxFuel;
			plr = GetComponent<PlayerController> ();
		}

		private void FixedUpdate()
		{
			if (Input.GetKey(KeyCode.LeftControl) && !plr.inWater)
			{
				if (fuel > 0f) {
					jetpacking = true;
					fuel -= consumptionRate;
					if (rb.velocity.y < maxVerticalSpeed)
						rb.velocity += force * Time.fixedDeltaTime;
					else
						rb.velocity = new Vector2 (0f, maxVerticalSpeed);
				} else
					jetpacking = false;
			}
			else
			{
				jetpacking = false;
				if (fuel < 100f)
				{
					fuel += Time.fixedDeltaTime*75;
				}
			}

			JetpackBar.value = fuel / maxFuel;

	        animator.SetBool("isUsingJetPack", jetpacking);

	    }

		public void setFuel(float value){
			fuelMultiplier = value;
		}

	}
}