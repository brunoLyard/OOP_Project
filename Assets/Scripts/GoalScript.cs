using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public ParticleSystem win;
    void Start()
    {
        win.Stop();
    }
    void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("Player") && GameManager.Instance.isItem)
        {
            win.Play();
            //GameManager.Instance.PauseGame();
        }
    }

    
}
