using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Enemy targetEnemy;
    private float speed = 10;
    void Update()
    {
        if(targetEnemy == null)
        {
            Destroy(gameObject);
            return;
        }

        var v = targetEnemy.transform.position - transform.position;
        transform.position += v.normalized * speed * Time.deltaTime;

        if (v.magnitude < 0.7f)
        {
            targetEnemy.hp -= 1;
            if (targetEnemy.hp <= 0)
            {
                Destroy(targetEnemy.gameObject);
                FindObjectOfType<Player>().gold += targetEnemy.gold;
            }
            transform.SetParent(targetEnemy.transform);
            enabled = false;
        }
        
    }
}
