using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cephalon9;

public class PlayerShield : MonoBehaviour {

    private float shield;
    private float maxShield;

    public GameObject shieldfGfx;

    [SerializeField] private Slider shieldBar;

    void Start()
    {

        //loadMaxShield from save
        maxShield = 50;

        shield = maxShield;
    }

    void Update()
    {
        shieldBar.value = shield / maxShield;
    }

    public void takeDamage(float damage)
    {
        if (shield > 0)
            shield -= damage;

        if (shield <= 0)
        {
            //disable shield
            shieldfGfx.SetActive(false);
        }
    }

}
