using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Wave[] waves;
    public int wave;
    public float time;

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateEnemy()
    {
        foreach (var pattern in waves[wave].patterns)
        {
            if (pattern.time <= time)
            {
                var enemy = Instantiate(pattern.enemy, new Vector3(-1000, -1000), Quaternion.identity);
                enemy.route = pattern.route;
            }
        }

        waves[wave].patterns.RemoveAll(pattern => pattern.time <= time);
    }
}

[SerializeField]
public class Wave
{
    public List<EnemyPattern> patterns;
}

[SerializeField]
public class EnemyPattern
{
    public float time;
    public Enemy enemy;
    public Route route;
}