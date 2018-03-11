using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroBullet : MonoBehaviour
{

    public enum Direction { NONE, LEFT, RIGHT };
    private Direction dir = Direction.NONE;
	public float damage;
    public float speed;
    public bool isEnemy;

    private void Start()
    {
        StartCoroutine(LifeTime());
    }

    private void Update()
    {
        if (dir == Direction.NONE)
            return;

        if (dir == Direction.LEFT)
            transform.position -= transform.right * speed * Time.deltaTime;
        else
            transform.position += transform.right * speed * Time.deltaTime;
    }

    private IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy" && !isEnemy)
        {
            coll.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (coll.tag == "Player" && isEnemy)
        {
            coll.GetComponent<PlayerController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Direction _dir)
    {
        dir = _dir;
    }

}
