using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBullet : Bullet
{

	public float damage;
	public float speed;

	private static float damageMultiplier=1;

	private void Start()
	{
		StartCoroutine(LifeTime());
	}

	private void Update()
	{
		if (dir == Direction.NONE)
			return;

		if (dir == Direction.LEFT)
			transform.position -= transform.right * speed * Time.deltaTime;
		else
			transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy")
		{
			coll.GetComponent<EnemyHealth>().TakeDamage(damage*damageMultiplier);
			Destroy(gameObject);
		}
	}

	public void SetDirection(Direction _dir)
	{
		dir = _dir;
	}

	public static void setDamage(float d){
		damageMultiplier = d;
	}
}
