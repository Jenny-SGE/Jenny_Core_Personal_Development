using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
 private Animator anim;
 private float moveSpeed = 8.0f;
 private float turnSpeed = 35f;

    void Start()
    {
        // Get the Animator component from the object
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Set the "isWalking" bool to true while W is held, false otherwise
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.A))
            {
                // Rotate left (negative Y axis)
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Rotate right (positive Y axis)
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
