using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour {

	[SerializeField]private Vector3 motion;

	void Update () {
		transform.Translate (motion*Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("boundBlock")) {
			this.motion = other.GetComponent <boundBlock> ().motion;
		}
	}

}
