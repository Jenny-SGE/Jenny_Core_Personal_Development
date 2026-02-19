using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 5.0f;
    private PlayerController playerScript;
    
    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
    
        if (playerObj != null)
        {
            playerScript = playerObj.GetComponent<PlayerController>();
        }
    
    }
    void Update()
    {
        
        if (!playerScript.gameOver)
        {
            transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destroy") && !playerScript.gameOver)
        {
            Destroy(gameObject);
        }
    }
}
