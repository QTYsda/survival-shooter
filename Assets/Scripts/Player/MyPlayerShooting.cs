using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerShooting : MonoBehaviour
{
    float time;
    public float 间隔时间 = 0.15f;
    private float 显示时间 = 0.2f;
    private AudioSource 枪声;
    private Light 枪火;
    private LineRenderer gunline;
    private ParticleSystem 粒子;
    private Ray shootRay;
    private RaycastHit shootHit;
    private int shootMask;
    private void Awake()
    {
        枪声 = GetComponent<AudioSource>();
        枪火 = GetComponent<Light>();
        gunline = GetComponent<LineRenderer>();
        粒子 = GetComponent<ParticleSystem>();
        shootMask = LayerMask.GetMask("怪物");
    }
        
    void Update()
    {
        time = time + Time.deltaTime;
        if(Input.GetButton("Fire1")&& time >= 间隔时间)
        {
            射击代码();
            
        }
        if(time >= 间隔时间 * 显示时间)
        {
            枪火.enabled = false;
            gunline.enabled = false;
        }
    }
    void 射击代码()
    {
        time = 0;
        枪火.enabled = true;
        gunline.SetPosition(0,transform.position);
        //gunline.SetPosition(1, transform.position + transform.forward * 100);
        gunline.enabled = true;
        粒子.Play();
        枪声.Play();
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        if(Physics.Raycast(shootRay,out shootHit,100,shootMask))
        {
            gunline.SetPosition(1,shootHit.point);
            MyEnemyHealth 怪物血量 = shootHit.collider.GetComponent<MyEnemyHealth>();
            怪物血量.TakeDamege(10, shootHit.point);
        }
        else
        {
            gunline.SetPosition(1, transform.position + transform.forward * 100);
        }
    }
    
      
    
}
