using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0f;
    private float attackCd = 0.3f;

    private Animator anim;

    public Collider2D attackTrigger;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.V) && !attacking)
        {
            attacking = true;
            attackTimer = attackCd;

            attackTrigger.enabled = true;
            Debug.Log("is Attacking");
        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }

        }

        anim.SetBool("isAttacking", attacking);

    }

    

}
