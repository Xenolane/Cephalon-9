using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public float damage;

	public bool left;

	public void setDirection(bool left){
		this.left = left;
		GetComponentInChildren<SpriteRenderer> ().flipX = left;
	}

	void Update(){
		transform.Translate (speed * ((left) ? -1 : 1)*Time.deltaTime, 0, 0);
	}

	protected IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject);
	}

}
