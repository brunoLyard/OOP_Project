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
    private bool isGround = true;
    private bool isItem = false;
    
    // intégration solution direction pour déplacer le personnage
    [SerializeField]
    private float speed = 4f;

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
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(HorizontalInput,0,VerticalInput);
        if (direction.magnitude>1f) direction.Normalize();

        transform.position += direction * speed * Time.deltaTime;

        if(direction.magnitude>0.03f)
        {
            playerAnimator.SetBool("walk", true);
            Quaternion rotationGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotationGoal, Time.deltaTime * 4f);
        }
        else playerAnimator.SetBool("walk",false);

            if ( Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            //isJump();
            shootProjectile();
        }

        if ( GameManager.Instance.isItem) ItemActive();
    }

    void OnCollisionEnter(Collision other)
    {
        if ( other.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("jump", false);
            isGround = true;
        }
        if ( other.gameObject.CompareTag("wall"))
        {
            Debug.Log("collision wall");
            playerRb.AddForce(Vector3.back * 20 , ForceMode.Impulse);
        }
    }

    private void isWalk()
    {
        playerAnimator.SetBool("walk", true);
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * VerticalInput * 3);
    }

    private void shootProjectile()
    {  
  /*               Instantiate(Projectile,
                     transform.position + Projectile.transform.position, 
                    Quaternion.identity); */
                    Instantiate(Projectile, transform);
        
    }

    private void isJump()
    {
        isGround = false;      
        playerRb.AddForce(Vector3.up * 5  , ForceMode.Impulse);
        playerAnimator.SetBool("jump", true);
    }

    public void ItemActive()
    {
        transform.Find("Item").gameObject.SetActive(true);
    }
}
