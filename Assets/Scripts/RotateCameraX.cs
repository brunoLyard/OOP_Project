using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraX : MonoBehaviour
{
    
    public GameObject player;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(x: player.transform.position.x ,
                                         y: 0,
                                         z: player.transform.position.z);
    }
}
