using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    [SerializeField] private int enemyLife = 2;

    public static EnemyInfo instance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        LifeHandler(collision);
    }

    private void LifeHandler(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            enemyLife--;
        }
        if (enemyLife <= 0)
        {
            GameManager.instance.SetGameScore(1);   
            Destroy(this.gameObject);
        }
    }

}
