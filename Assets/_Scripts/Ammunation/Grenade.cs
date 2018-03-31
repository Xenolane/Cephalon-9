using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour {

	private float damage=50;
	public static float damageMultiplier=0;

	private bool exploded = false;
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
		anim.speed = 0;
		StartCoroutine (explode ());
	}
	
	IEnumerator explode(){
		yield return new WaitForSeconds (3);
		anim.speed = 1;
		yield return new WaitForSeconds (1f);
		exploded = true;
	}

	void OnTriggerStay2D(Collider2D other){
		if (exploded) {
			other.SendMessage ("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}
	}
}
