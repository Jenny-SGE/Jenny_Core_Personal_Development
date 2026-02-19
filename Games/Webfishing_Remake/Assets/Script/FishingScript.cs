using UnityEngine;
using UnityEngine.Android;

public class FishingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator m_Animator;

 

    void Start()
    {
        // Get the Animator component attached to this GameObject
        m_Animator = GetComponent<Animator>();
        m_Animator.SetBool("isFishing", false);
        
    }

    void Update()
    {
        // Check for a specific input, such as the Space key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Set the trigger to activate the transition

            m_Animator.SetBool("isFishing", true);
            Debug.Log("Key is down fishing can begin");
        }
         if (Input.GetKeyUp(KeyCode.Space))
        {
            // Set the trigger to activate the transition

            m_Animator.SetBool("isFishing", false);
            Debug.Log("Key is up no more fishing");
        }
    }

}
