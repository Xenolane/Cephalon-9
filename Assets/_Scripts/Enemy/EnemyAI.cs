using UnityEngine;
using System.Collections;
using Cephalon9;

namespace Cephalon9{
	public class EnemyAI : MonoBehaviour {

		public enum State{
			PATROLLING, CHASING, ATTACKING, DYING
		}

		[Header("Components")]
		Rigidbody2D rb;
		[SerializeField]Transform lLimit;
		[SerializeField]Transform rLimit;
		[SerializeField]Animator anim;
		[SerializeField]SpriteRenderer spr;
		[SerializeField]EnemyScanner scanner;

		[Header("Properties")]
		[SerializeField]private float speed;
		public float health;
		[SerializeField]private float damage;

		//private variables
		public bool right=true;
		private State state;
		private Transform plr;
		private bool attacking=false;
		private bool dead=false;
		private bool canAttack=true;


		void Start(){
			rb = GetComponent<Rigidbody2D> ();
			state = State.PATROLLING;
			plr = GameObject.FindGameObjectWithTag ("Player").transform;
			health = 100;
		}

		void Update(){
			switch (state) {
			case State.PATROLLING:
				patrol ();
				break;
			case State.CHASING:
				chase ();
				break;
			case State.ATTACKING:
				attack ();
				break;
			case State.DYING:
				die ();
				break;
			default:
				state = State.PATROLLING;
				break;
			}
				
		}

		void LateUpdate(){
			spr.flipX = right;

			if (!dead) {
				if (health <= 0) {
					state = State.DYING;
					StartCoroutine ("death");
				}
			}
		}

		void patrol(){
			anim.SetBool ("isWalking", true);

			if (transform.position.x <= lLimit.position.x)
				right = true;
			if (transform.position.x >= rLimit.position.x)
				right = false;

			transform.Translate (speed * Time.deltaTime * (right ? 1 : -1), 0, 0);

			EnemyScanner.Range range = scanner.getRange();

			if (range == EnemyScanner.Range.MEDIUM || range == EnemyScanner.Range.CLOSE)
				state = State.CHASING;
		}

		void chase(){
			EnemyScanner.Range range = scanner.getRange();

			if (range == EnemyScanner.Range.FAR || range == EnemyScanner.Range.NONE) {
				//or shoot
				state = State.PATROLLING;
			}
				
			if (range == EnemyScanner.Range.MEDIUM) {
				if (plr.position.x - transform.position.x > 1.5f)
					right = true;
				if (plr.position.x - transform.position.x < -1.5f)
					right = false;

				transform.Translate (speed * Time.deltaTime * (right ? 1 : -1), 0, 0);
			}

			if (range == EnemyScanner.Range.CLOSE)
				state = State.ATTACKING;
			
		}

		void attack(){
			//melee

			EnemyScanner.Range range = scanner.getRange();

			if (range == EnemyScanner.Range.NONE)
            {
                    right = !right;
                    state = State.CHASING;
			}

			if (range != EnemyScanner.Range.CLOSE) {
				//or shoot
				state = State.CHASING;
				anim.SetBool("melee",false);
				return;
			}
			anim.SetBool("melee",true);
		}

		void die(){
			speed = 0;
			damage = 0;
		}

		IEnumerator death(){
			dead = true;
			anim.SetTrigger ("dying");
			yield return new WaitForSeconds (4f);
			Destroy (gameObject);
		}

		void OnTriggerStay2D(Collider2D other){
			if (other.CompareTag ("Player"))
            {
				if (state == State.ATTACKING)
                {
					if (canAttack) {
						StartCoroutine ("giveDamage");
					}
				}

                
			}
		}
			
		private IEnumerator giveDamage(){
			canAttack = false;
			plr.GetComponent<PlayerHealth> ().takeDamage (damage);
			yield return new WaitForSeconds (1);
			canAttack = true;
		}

		public void takeDamage(float d){
			if (health > 0)
				health -= d;
		}

	}
}