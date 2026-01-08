using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]int walkspeed;
    [SerializeField]int runspeed;
    int speed;
    Rigidbody2D rigidbody;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody2D component attached to the player GameObject
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement input
        PlayerMove();
    }

    void PlayerMove()
    {
        // Reset velocity to zero before applying new movement
        rigidbody.linearVelocity = Vector3.zero;

        // Move the player based on input keys
        if (Input.GetKey(KeyCode.W))
        {
            Move(transform.up);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Move(-transform.up);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-transform.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
        }
        // Adjust speed based on whether the Left Shift key is held down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runspeed;
        }
        else
        {
            speed = walkspeed;
        }
    }

    // Move the player in the specified direction
    void Move(Vector3 direction)
    {
        // Set the player's velocity in the specified direction multiplied by speed
        rigidbody.linearVelocity = direction * speed;
    }
}
