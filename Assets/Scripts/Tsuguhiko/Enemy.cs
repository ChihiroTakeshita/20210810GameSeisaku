using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] float speed;
    [SerializeField] int gold;
    [SerializeField] Route route;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = route.points[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var v = Vector3.right; // 移動方向 右
        transform.position += v * speed * Time.deltaTime;
    }
}
