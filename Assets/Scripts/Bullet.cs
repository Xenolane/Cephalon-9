using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public enum Direction { NONE, LEFT, RIGHT };
	protected Direction dir = Direction.NONE;

	protected IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject);
	}

	public void SetDirection(Direction _dir)
	{
		dir = _dir;
	}
}
