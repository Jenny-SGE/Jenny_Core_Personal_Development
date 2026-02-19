using UnityEngine;
using Unity.Collections;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
private Rigidbody playerRB;
public float jumpForce = 10;
[SerializeField]
private float delayDeath = 0.1f;
public float gravityMod;
public float speed = 5f;
public bool isOnGround = true;
public bool gameOver = false;
public ParticleSystem bloodsSplat;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
    }
    void FixedUpdate()
    {
        if (!gameOver)
        {   
            float moveInput = -Input.GetAxis("Horizontal"); 
            playerRB.linearVelocity = new Vector3(moveInput * speed, playerRB.linearVelocity.y, playerRB.linearVelocity.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            Debug.Log("isJumping");
        }
    }

    public void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnGround = true;
            Debug.Log("isOnGround");
        }
        else if (collision.collider.CompareTag("Obstacle"))
        {
            Invoke ("DelayGameover", delayDeath);
        }
    }

    private void DelayGameover()
    {
        gameOver = true;
        Debug.Log("Game Over!");
        //Should unfreeze
        playerRB.constraints = RigidbodyConstraints.None;
        bloodsSplat.Play();
    }
}

