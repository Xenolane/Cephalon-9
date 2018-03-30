using UnityEngine;
using Cephalon9;

namespace Cephalon9{
	public class PlayerController : MonoBehaviour {

		[Header("Properties")]
		[SerializeField]private float jumpForce;
		[SerializeField]private float speed;

		[Header("Components")]
		[SerializeField]private Transform ground;
		[SerializeField]private LayerMask groundLayer;
		[SerializeField]SpriteRenderer sprite;
		private Rigidbody2D rb;

		//private variables
		private bool grounded=false;
		private bool right=true;

		void Start (){
			rb = this.GetComponent<Rigidbody2D> ();
		}

		void FixedUpdate(){
			processMovement ();

			if (Input.GetKeyDown (KeyCode.Space))
				jump ();
		}

		//ground Test
		void LateUpdate () {
			grounded = Physics2D.OverlapCircle (ground.position, 0.01f, groundLayer);
			processFacing ();
		}

		//private functions
		void jump(){
			if (grounded) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			}
		}

		void processMovement(){
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);
		}

		void processFacing(){
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow))
				right = false;
			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow))
				right = true;
			if (Input.GetAxis ("Horizontal") > 0)
				right = true;
			else if (Input.GetAxis ("Horizontal") < 0)
				right = false;
				
			sprite.flipX = !right;
		}
	}
}