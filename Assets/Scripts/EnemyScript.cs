using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    float speed = 3.5f;

    public bool isTouch = false;


    Vector3 moveToP = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<GameObject>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( !isTouch)
        {
        Vector3 temp = new Vector3();
        temp = player.transform.position - transform.position;
        rotateEnemy(temp);
        moveToPlayer(temp);
        
        }
    }

    void moveToPlayer(Vector3 temp)
    {
        temp.Normalize();
        moveToP = transform.position + temp * Time.deltaTime * speed;
        moveToP.y = 0;
        transform.position = moveToP;       
    }

    void rotateEnemy(Vector3 toRotate)
    {
        transform.rotation = Quaternion.LookRotation(toRotate);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            isTouch = true;
        }
    }
}
