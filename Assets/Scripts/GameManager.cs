using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager instance = null;
   public static GameManager Instance => instance;



   
   public bool IsGameOver = false;
   public bool isItem;
  
   public string PlayerName;
    
    void Awake()
    {
        if ( instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
   
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
