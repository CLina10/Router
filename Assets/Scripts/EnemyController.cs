using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health = 5f;
    public int countValue = 1;
    public AI ai;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            health -= 1;

            if (health == 0)
            {
                ai.enemyVehicles.Remove(this.GetComponent<EnemyVehicle>());
                ai.defaultEnemyPool.ReturnToPool(gameObject);
                EnemyCounter.count += countValue;
            }
        }
    }
}