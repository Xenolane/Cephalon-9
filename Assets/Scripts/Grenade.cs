using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour {

	private float damage=50;
	public static float damageMultiplier=0;

	void Start () {
		StartCoroutine (explode ());
	}
	
	IEnumerator explode(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
		//explosion
	}
}
