using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

    public Transform sightStart, sightEnd;
    public bool spotted = false;
	
	void Update ()
    {
        Raycasting();
	}


    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.blue);
        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
    }

   
}
