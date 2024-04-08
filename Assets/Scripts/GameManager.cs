using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject fail, win, end;
    public static GameManager Instance { get; private set; }
    public GameStage GameStage { get; private set; }

    public int score = 0;
    public int level = 1;
  
    public Rotater rotater;
    public Spawner spawner;
    public Animator animator;


    private void Start()
    {
        level = PlayerPrefs.GetInt("Level", 1); 

        Time.timeScale = 1.0f;
        fail.SetActive(false);
        win.SetActive(false);
        end.SetActive(false);
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

   
    private void Update()
    {
        NewLevel();
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();
    }


    public void EndGame()
    {
        rotater.enabled = false;
        spawner.enabled = false;
        
        SetGameStage(GameStage.Fail);
        
        PlayerPrefs.SetInt("Level", level);
        PlayerPrefs.Save();

    }

    public void NewLevel()
    {

       
        if (score == 2)
        {
            Debug.Log("WIN1");
            level++;
            if (level <= 4)
            {
                Debug.Log("WIN2");

                level--;
                score = 0;
                SetGameStage(GameStage.Win);
                
            }
            else
            {
                level--;
                end.SetActive(true);
            }
            Time.timeScale = 0f;

        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetGameStage(GameStage gameStage)
    {
        if (gameStage == GameStage.Fail)
        {
            fail.SetActive(true);
            win.SetActive(false);
        }

        else
        {
            win.SetActive(true);
            fail.SetActive(false);
        }
    }
}

public enum GameStage { Started, Win, Fail }
