using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody projectileRb;
    private Quaternion direction;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        projectileRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        projectileRb.AddForce(player.transform.forward * 200 *Time.deltaTime , ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if ( other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
