using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour {

	void Start () {
		StartCoroutine (explode ());
	}
	
	IEnumerator explode(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
}
