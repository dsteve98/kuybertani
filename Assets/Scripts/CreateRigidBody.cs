using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRigidbody : MonoBehaviour
{
    public static SpawnRigidbody main;
    public Rigidbody2D ball;
    Vector2 sp = new Vector2(0f, 2.1f);

    void Awake()
    {
        main = this;
    }
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float x = Random.Range(-17f, 11f);
        sp = new Vector2(x, -5f);
        Debug.Log("spawn");
        GameObject go = Instantiate(ball, sp, transform.rotation).gameObject;
    }
}