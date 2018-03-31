using UnityEngine;
using UnityEngine.UI;
using Cephalon9;

namespace Cephalon9{
	public class PlayerHealth : MonoBehaviour {

		private float health;
		private float maxHealth;

		[SerializeField]private Slider healthBar;

		void Start () {

			//loadMaxHealth from save
			maxHealth=100;

			health = maxHealth;
		}

		void Update(){
			healthBar.value = health / maxHealth;
		}

		public void takeDamage(float damage){
			if (health > 0)
				health -= damage;

			if (health <= 0) {
				//die
			}
		}

	}
}