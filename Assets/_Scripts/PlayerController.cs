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
		AudioSource footsteps;

		public Animator anim;
		private Rigidbody2D rb;
		private PlayerWeapon weapon;

		//private variables
		private bool grounded=false;
		[HideInInspector]public bool right=true;

		void Start (){
			rb = this.GetComponent<Rigidbody2D> ();
			weapon = this.GetComponent<PlayerWeapon> ();
			footsteps = GetComponent<AudioSource> ();
		}

		void Update(){
			if (Input.GetMouseButtonDown (0))
				weapon.StartCoroutine ("shoot");
			if(Input.GetMouseButtonUp(1))
				weapon.StartCoroutine ("launchGrenade");
		}

		void FixedUpdate(){
			processMovement ();

			if (Input.GetKeyDown (KeyCode.Space))
				jump ();
		}

		//ground Test
		void LateUpdate () {
			grounded = Physics2D.OverlapCircle (ground.position, 0.01f, groundLayer);
			anim.SetBool ("grounded", grounded);
			processFacing ();
		}

		//private functions
		void jump(){
			if (grounded) {
				anim.SetTrigger ("jumping");
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			}
		}

		//movement
		void processMovement(){
			rb.velocity = new Vector2 (Input.GetAxis ("Horizontal") * speed, rb.velocity.y);
		}

		//sprite Handling
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

			if (rb.velocity.x != 0)
				anim.SetBool ("isWalking", true);
			else
				anim.SetBool ("isWalking", false);
		}

		void processAudio(){
			if (rb.velocity.x != 0 && grounded) {
				if (footsteps.isPlaying)
					return;
				footsteps.Play ();
			}
		}


	}	
}