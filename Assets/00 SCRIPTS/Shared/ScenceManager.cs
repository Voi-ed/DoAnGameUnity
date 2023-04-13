using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class ScenceManager : MonoBehaviour
{
    public void load00()
    {
        SceneManager.LoadScene(0);
        AudioController.Instant.playSound("Compressed");
    }
    public void load0()
    {
        SceneManager.LoadScene(0);
        AudioController.Instant.playSound("Compressed");
    }
  public void topdown()
    {
        SceneManager.LoadScene(3);
        AudioController.Instant.playSound("Compressed");
    }
    public void Platformer()
    {
        AudioController.Instant.playSound("Compressed");
        SceneManager.LoadScene(2);
    }
    public void SelectMap()
    {
        AudioController.Instant.playSound("Compressed");
        SceneManager.LoadScene(1);
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TurnOnSourd(GameObject s )
    {
        if (s.activeSelf)
        {
            s.SetActive(false);
        }
        else
        {
            s.SetActive(true);
        }
    }
   

}
