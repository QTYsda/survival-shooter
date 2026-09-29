using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public GameObject Enemy;
    private float CreatEnemyTime = 0;
    public GameObject CreatEnemyPoint;
    public float 刷怪间隔 = 3;
    // Update is called once per frame
    private void Start()
    {
        InvokeRepeating("Spawn", CreatEnemyTime, 刷怪间隔);
    }
    private void Spawn()
    {
        
        Instantiate(Enemy,CreatEnemyPoint.transform.position,
            CreatEnemyPoint.transform.rotation);
    }
}
