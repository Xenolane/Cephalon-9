using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    // Singleton
    private static PlayerStats _instance;
    public static PlayerStats Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlayerStats>();
            }

            return _instance;
        }
    }



}
