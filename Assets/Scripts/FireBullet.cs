using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{

	public enum Direction { NONE, LEFT, RIGHT };
	private Direction dir = Direction.NONE;
	public float damage;
	public float speed;
	public bool isEnemy;

	public static float damageMultiplier=1;
	public static float speedMultiplier=1;

	private void Start()
	{
		StartCoroutine(LifeTime());
	}

	private void Update()
	{
		if (dir == Direction.NONE)
			return;

		if (dir == Direction.LEFT)
			transform.position -= transform.right * speed *speedMultiplier* Time.deltaTime;
		else
			transform.position += transform.right * speed *speedMultiplier* Time.deltaTime;
	}

	private IEnumerator LifeTime()
	{
		yield return new WaitForSeconds(3.0f);
		Destroy(gameObject);
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy" && !isEnemy)
		{
			coll.GetComponent<EnemyHealth>().TakeDamage(damage*damageMultiplier);
			Destroy(gameObject);
		}
		else if (coll.tag == "Player" && isEnemy)
		{
			coll.GetComponent<PlayerController>().TakeDamage(damage*damageMultiplier);
			Destroy(gameObject);
		}
	}

	public void SetDirection(Direction _dir)
	{
		dir = _dir;
	}

}
