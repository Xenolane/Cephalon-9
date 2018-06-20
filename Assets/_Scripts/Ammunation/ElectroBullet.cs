using UnityEngine;
using Cephalon9;

namespace Cephalon9{
public class ElectroBullet : Bullet
{

	private static float damageMultiplier=1;

	private void Start()
	{
		StartCoroutine(LifeTime());
	}

	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.CompareTag ("Ground"))
				Destroy (this.gameObject);

		if (coll.CompareTag ("Enemy"))
        {
			coll.GetComponent<EnemyAI> ().takeDamage (damage);
			Destroy (gameObject);
		}

            if (coll.CompareTag("SpaceEnemy"))
            {
                coll.GetComponent<SpaceEnemyAI>().takeDamage(damage);
                Destroy(gameObject);
            }

            if (coll.CompareTag("Player"))
        {
			coll.GetComponent<PlayerHealth> ().takeDamage (damage);
			Destroy(gameObject);
		}
	}

	public static void setDamage(float d)
    {
		damageMultiplier = d;
	}

}
}