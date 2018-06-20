using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipWeapon : MonoBehaviour {

    private float fireDelay = 0.5f;
    private float cooldownTime = 0;

    [Header("Components")]

    [SerializeField] Transform area;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private AudioSource aSource;
    [SerializeField] private Vector3 bulletOffset = new Vector3(0, 0.5f, 0);
    [Header("Ammo")]

    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject bullet;

    private PlayerSpaceController plr;
    private GameObject activeBullet;
    // Update is called once per frame
    void Update ()
    {
        cooldownTime -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTime <= 0)
        {
            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bullet, transform.position + offset, transform.rotation);
        }
	}
}
