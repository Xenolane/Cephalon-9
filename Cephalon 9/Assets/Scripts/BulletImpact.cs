using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : MonoBehaviour {

    private float Damage = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.GetComponent<EnemyHealth>().TakeDamage(Damage);
        }
    }
}
