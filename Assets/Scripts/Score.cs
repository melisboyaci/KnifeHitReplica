using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
public class Score : MonoBehaviour
{


    public static int PinCount;

    public TMP_Text level;
    public TMP_Text remaining;


    

    void Start()
    {
        PinCount = GameManager.Instance.score;
       
    }

    void Update()
    {
        PinCount = GameManager.Instance.score;
        level.text = GameManager.Instance.level + "";
        if (PinCount >= 2)
        {
            remaining.text = "Remaining Pin: 0";
        }
        else
            remaining.text = "Remaining Pin: " + (2-PinCount).ToString();
    }


    
}
