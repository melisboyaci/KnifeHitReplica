using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    public void RetryButton()
    {
        GameManager.Instance.fail.SetActive(false);
        GameManager.Instance.win.SetActive(false);
        GameManager.Instance.Restart();
    }
    public void NextLevelButton() { 
        GameManager.Instance.win.SetActive(false);
        GameManager.Instance.fail.SetActive(false);
        GameManager.Instance.level++;
        PlayerPrefs.SetInt("Level", GameManager.Instance.level);   
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("Level"));
        Time.timeScale = 1.0f;
    }

    public void PlayAgainButton() {
        GameManager.Instance.end.SetActive(false);
        GameManager.Instance.level = 1;
        GameManager.Instance.score = 0;
        SceneManager.LoadScene("Level1");
        PlayerPrefs.DeleteAll();
    }
}
