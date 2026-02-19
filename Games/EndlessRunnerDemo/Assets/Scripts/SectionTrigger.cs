using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
public GameObject[] platformRange;
private float halfWidth = 20f;
private PlayerController playerScript;
    
    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
    
        if (playerObj != null)
        {
            playerScript = playerObj.GetComponent<PlayerController>();
        }
    }
        private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Trigger") && !playerScript.gameOver)
        {
            int index = Random.Range(0, platformRange.Length);
            Instantiate(platformRange[index], new Vector3(0, 0, -halfWidth), Quaternion.identity);
        }
    }
}
     