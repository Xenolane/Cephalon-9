using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    private bool dirLeft;

    private Transform enemy;

    private Rigidbody2D r2D;

    private Animator myAnimator;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
