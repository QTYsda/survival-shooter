using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyHealth : MonoBehaviour
{
    public AudioClip 死亡音效;
    public int 怪物血量 = 50;
    private AudioSource 受击音效;
    private ParticleSystem 受击特效;
    private Animator 死亡动画;
    private CapsuleCollider 死掉了;
    public bool 是否死亡 = false;
    private bool IsSiking = false;
    private void Awake()
    {
        受击音效 = GetComponent<AudioSource>();
        受击特效 = GetComponentInChildren<ParticleSystem>();
        死亡动画 = GetComponent<Animator>();
        死掉了 = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        if(IsSiking)
        {
            transform.Translate(-transform.up * Time.deltaTime);
        }
    }
    public void TakeDamege(int amount,Vector3 hitPoint)
    {
        if (是否死亡)
            return;
        受击音效.Play();
        受击特效.transform.position = hitPoint;
        受击特效.Play();
        怪物血量 -= amount;
        if (怪物血量 <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        是否死亡 = true;
        MyScoreManager.Score += 10;
        死亡动画.SetTrigger("Death");
        死掉了.enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        受击音效.clip = 死亡音效;
        受击音效.Play();
    }
    public void StartSinking()
    {
        IsSiking = true;
        Destroy(gameObject, 2f);
    }
}
