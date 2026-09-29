using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyEnemyAtk : MonoBehaviour
{
    private float timer = 0;
    private GameObject player;
    private bool 玩家是否受伤 = false;
    private MyPlayerHealth 玩家血量;
    private Animator enemyAnim;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        玩家血量 = player.GetComponent<MyPlayerHealth>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!玩家血量.玩家是否死亡 && 玩家是否受伤 && timer > 1.5f)
        {
            Attack();
        }
        if(玩家血量.玩家是否死亡)
        {
            enemyAnim.SetTrigger("PlayerDead");
        }
    }

    private void Attack()
    {
        timer = 0;
        玩家血量.TakeDamege(10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            玩家是否受伤 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            玩家是否受伤 = false;
        }
    }
}
