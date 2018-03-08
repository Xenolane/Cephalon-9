using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meelee : MonoBehaviour
{
    private EnemyAI enemy;
    [HideInInspector]
    public float range = 1.2f;



    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (!enemy.detectedPlayer)
            return;

        if (enemy.hasBoth)
        {
            if (enemy.range == EnemyAI.Range.MEDIUM)
            {
                enemy.ChasePlayer();
            }
        }
        else
        {
            enemy.ChasePlayer();
        }
    }

    

}
