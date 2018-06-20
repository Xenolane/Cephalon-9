using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceEnemyAI : MonoBehaviour {

    private float rotSpeed = 5f;
    private Transform player;
    private float health;
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void takeDamage(float d)
    {
        if (health > 0)
            health -= d;
    }
}
