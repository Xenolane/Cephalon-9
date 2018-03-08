using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

    public float moveSpeed = 5f;
    public float damage = 5f;
    public float health = 100f;

    private Vector2 enemyPosition;
    private bool dirLeft;
    private Transform enemy;
    private Rigidbody2D r2D;
	
	void Start ()
    {
        enemy = this.gameObject.transform;
        r2D = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	
	void Update ()
    {
        enemyPosition.x = moveSpeed;
        r2D.velocity = enemyPosition;


	}
}
