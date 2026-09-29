using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyPlayerHealth : MonoBehaviour
{
    public AudioClip 玩家死亡音效;
    private int 玩家血量 = 100;
    public bool 玩家是否死亡 = false;
    private AudioSource 受伤音效;
    public Text PlayerHealthUI;
    public Image DamageImage;
    public Color FlashColor = new Color(1f,0f,0f,0.1f);
    private Animator 玩家死亡动画;
    private PlayerMovement playerMovement;
    private MyPlayerShooting myPlayerShooting;
    private bool damaged = false;

    private void Awake()
    {
        受伤音效 = GetComponent<AudioSource>();
        玩家死亡动画 = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        myPlayerShooting = GetComponentInChildren<MyPlayerShooting>();
    }

    
    void Update()
    {
        if (damaged)
            DamageImage.color = FlashColor;
        else
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear,20f*Time.deltaTime);
        damaged = false;
    }
    public void TakeDamege(int amount)
    {
        if (玩家是否死亡)
            return;
        damaged = true;
        受伤音效.Play();
        玩家血量 -= amount;
        PlayerHealthUI.text = 玩家血量.ToString();
        //print(玩家血量);
        if(玩家血量 == 0)
        {
            Death();
        }
    }
    void Death()
    {
        玩家是否死亡 = true;
        受伤音效.clip = 玩家死亡音效;
        受伤音效.Play();
        玩家死亡动画.SetTrigger("Die");
        playerMovement.enabled = false;
        myPlayerShooting.enabled = false;
    } 
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
