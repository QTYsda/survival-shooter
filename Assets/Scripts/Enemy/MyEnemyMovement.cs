using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyMovement : MonoBehaviour
{
    private MyEnemyHealth health;
    private GameObject player;
    private NavMeshAgent nav;
    private MyPlayerHealth myPlayerHealth;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
        health = GetComponent<MyEnemyHealth>();
        myPlayerHealth = player.GetComponent<MyPlayerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!health.是否死亡 && !myPlayerHealth.玩家是否死亡)
        {
            nav.SetDestination(player.transform.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
