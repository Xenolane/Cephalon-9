using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : Bullet
{
	private static float damageMultiplier=1;

	private void Start()
	{
		StartCoroutine(LifeTime());
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Enemy")
		{
			coll.GetComponent<EnemyHealth>().TakeDamage(damage*damageMultiplier);
			Destroy(gameObject);
		}
	}

	public static void setDamage(float d){
		damageMultiplier = d;
	}
}
