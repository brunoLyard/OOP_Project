using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject FocalPoint;

    private float VerticalInput;
    private float HorizontalInput;
    
    [SerializeField]
    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb =  GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(FocalPoint.transform.forward * VerticalInput * Time.deltaTime * speed, ForceMode.Impulse);
        HorizontalInput = Input.GetAxis("Horizontal");
        //playerRb.AddForce(Vector3.left  * HorizontalInput * Time.deltaTime, ForceMode.Impulse);
        transform.Rotate(new Vector3(0,HorizontalInput * Time.deltaTime * speed,0));
        
    }
}
