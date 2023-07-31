using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject FocalPoint;
    private Animator playerAnimator;

    public GameObject Projectile;

    private float VerticalInput;
    private float HorizontalInput;
    
    private bool isItem = false;
    
    // intégration solution direction pour déplacer le personnage
    [SerializeField]
    private float speed = 5f;
    private float boostSpeed = 2;
    private bool isBoost = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb =  GetComponent<Rigidbody>();
        FocalPoint = GameObject.Find("Focal Point");
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.LeftShift))
        {
            isBoost = true;
        } 
        else if ( Input.GetKeyUp(KeyCode.LeftShift))
        {
            isBoost = false;
        }

        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(HorizontalInput,0,VerticalInput);
        if (direction.magnitude>1f) direction.Normalize();

        if ( !isBoost )
        transform.position += direction * speed * Time.deltaTime;
        else
        transform.position += direction * speed * boostSpeed * Time.deltaTime;

        if(direction.magnitude>0.03f)
        {
            playerAnimator.SetBool("walk", true);
            Quaternion rotationGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationGoal, Time.deltaTime * 4f);
        }
        else playerAnimator.SetBool("walk",false);

        if ( Input.GetKeyDown(KeyCode.Space))
        {
            shootProjectile();
        }


        if ( GameManager.Instance.isItem) ItemActive();
    }

    void OnCollisionEnter(Collision other)
    {
    }


    private void shootProjectile()
    {  
        Instantiate(Projectile, transform);      
    }

    public void ItemActive()
    {
        transform.Find("Item").gameObject.SetActive(true);
        GameManager.Instance.isItem = true;
    }
}
