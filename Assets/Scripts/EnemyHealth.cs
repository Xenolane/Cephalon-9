﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private bool dying = false;
    public float health = 100;
    public Image health_Bar;
	private bool melee = false;
	private bool attacking = false;
	private Animator anim;
	private LevelUp level;

	[SerializeField]private int points;

	void Awake()
	{
		anim = gameObject.GetComponent <Animator> ();
		level = GameObject.FindGameObjectWithTag ("Player").GetComponent<LevelUp> ();
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
        health_Bar.fillAmount = health / 100;

        if (health <= 0)
        {
			anim.SetBool ("isDying", dying);
			this.GetComponent<EnemyAI> ().dir = EnemyAI.Direction.NONE;
			dying = true;
			level.exp += points;
			Destroy(this.gameObject, 5);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (!attacking)
            {
                float damage = 5;
				anim.SetBool ("isMelee", melee);
				melee = true;
                coll.GetComponent<PlayerController>().TakeDamage(damage);
                StartCoroutine(DamageArea());
            }

        }


    }

    IEnumerator DamageArea()
    {
        attacking = true;

        yield return new WaitForSeconds(1);
        attacking = false;
    }
}
