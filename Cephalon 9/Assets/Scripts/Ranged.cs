using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : MonoBehaviour
{

    public GameObject BulletPrefab;
    private EnemyAI enemy;
    private float maxCooldown = 0.5f;
    private float timer;

    private void Start()
    {
        enemy = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if (enemy.hasBoth)
        {
            if (enemy.range == EnemyAI.Range.FAR)
            {
                Shoot();
            }
        }
        else
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= maxCooldown)
        {
            timer = 0f;
            GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.GetComponent<ElectroBullet>().SetDirection(enemy.dir == EnemyAI.Direction.LEFT ? ElectroBullet.Direction.RIGHT : ElectroBullet.Direction.LEFT);
            bullet.GetComponent<ElectroBullet>().isEnemy = true;
        }
    }

}
