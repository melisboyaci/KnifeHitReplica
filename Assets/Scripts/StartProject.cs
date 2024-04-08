using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartProject : MonoBehaviour
{
   
   public void StartButton()
    {
        SceneManager.LoadScene("Level" + GameManager.Instance.level.ToString()); ;
    }
}
