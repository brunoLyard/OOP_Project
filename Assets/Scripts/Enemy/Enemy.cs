using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private GameObject player;

    protected float speed;
    public float m_speed {
        get 
        {
            return speed;
        }
        set 
        {
            speed = value;
        }
    }

    Vector3 temp = new Vector3();
    
    void Awake()
    {
        SetSpeed();     
        player = GameObject.Find("Player");  
        
        
    }
    void Update()
    {

        rotateEnemy();
        moveToPlayer();
    }

    protected abstract void SetSpeed();

    public void moveToPlayer()
    {
        
        temp = player.transform.position - transform.position;
        temp.Normalize();
        Vector3 moveToP = transform.position + temp * Time.deltaTime * speed;
        moveToP.y = 0;
        transform.position = moveToP;       
    }

    public void rotateEnemy()
    {
        transform.rotation = Quaternion.LookRotation(temp);
    }
    void OnCollisionEnter(Collision other)
    {
         if (other.collider.CompareTag("Player"))
        {
            GameManager.Instance.IsGameOver = true;
        }
    }
}
