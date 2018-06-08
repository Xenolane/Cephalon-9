using UnityEngine;
using UnityEngine.UI;
using Cephalon9;

namespace Cephalon9{
	public class PointSystem : MonoBehaviour {

		[SerializeField] private Text pointsText;
		public int points=0;

		void Update ()
	    {
			pointsText.text = points + "";
		}

		void OnTriggerEnter2D(Collider2D other){
			if (other.CompareTag ("Coin")) {
				Destroy (other.gameObject);
				points += 1;
			}
		}
	}
}