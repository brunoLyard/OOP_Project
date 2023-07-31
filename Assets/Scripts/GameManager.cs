using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private static GameManager instance = null;
   public static GameManager Instance => instance;

   public bool isItem = false;// { get ; private set;}
   public bool IsGameOver = false;
    
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

    public void ItemTouch()
    {
        isItem = true;
    }

}
