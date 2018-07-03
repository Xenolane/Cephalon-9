using UnityEngine;
using Cephalon9;

namespace Cephalon9{
	public class EnemyScanner : MonoBehaviour{

		public enum Range{
			CLOSE, MEDIUM, FAR, NONE
		}

		public bool detected=false;
		private Transform plr;

		[SerializeField]EnemyAI enemy;

		void Start(){
			plr = GameObject.FindGameObjectWithTag ("Player").transform;
		}

		void Update(){
			if (enemy.right)
				transform.rotation = Quaternion.identity;
			else
				transform.rotation = Quaternion.Euler (0, 180, 0);

		}

		void OnTriggerStay2D(Collider2D other){
			if (other.CompareTag("Player"))
            {
				detected = true;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

                if (hit.collider.CompareTag("Ground"))
                {
                    detected = false;
                }
                else
                {
                    detected = true;
                }
			}
		}

		void OnTriggerExit2D(Collider2D other){
            if (other.CompareTag("Player"))
            {
                detected = false;
            }
		}

		public Range getRange(){
			if (detected) {
				Range dist=Range.NONE;
				if (Mathf.Abs(transform.position.x-plr.position.x) > 0)
					dist = Range.CLOSE;
				if (Mathf.Abs(transform.position.x-plr.position.x) > 0.5f)
					dist = Range.MEDIUM;
				if (Mathf.Abs(transform.position.x-plr.position.x) > 2f)
					dist = Range.FAR;

				return dist;
			} else {
				return Range.NONE;
			}
		}
			
	}
}