using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScoreManager : MonoBehaviour
{
    public static int Score = 0;
    public Text 分数;
    // Update is called once per frame
    void Update()
    {
        分数.text = $"Score:{Score}";
    }
}
