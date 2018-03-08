using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour {
	public float waitTime = 2;

	// Use this for initialization
	void Start () {
		StartCoroutine(Begin());
	}

	IEnumerator Begin()
	{
		yield return new WaitForSecondsRealtime(waitTime);
		Destroy(this.gameObject);
	}





}
