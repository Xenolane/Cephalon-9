using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceController : MonoBehaviour
{
    public Animator anim;

    private ShipWeapon cannon;

    private float maxSpeed = 5f;

    private float rotSpeed = 180f;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        //Rotate The Ship

        //Grab the rotation quaternion
        Quaternion rot = transform.rotation;

        //Grab the Z Euler Angle
        float z = rot.eulerAngles.z;

        // Change the Z angle based on Input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        //Recreate the Quaternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into the rotation
        transform.rotation = rot;

        //Move The Ship
        //Returns a FLOAT from -1.0 to +1.0
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;
        

        transform.position = pos;
    }
}
