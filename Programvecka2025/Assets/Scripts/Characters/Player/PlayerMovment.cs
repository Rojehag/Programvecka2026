using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Movement speed variables
    [SerializeField]int walkspeed;
    [SerializeField]int runspeed;
    int speed;

    [SerializeField] List<Sprite> playerSprites = new List<Sprite>();

    // Reference to the Rigidbody2D component
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
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        }
        if(Input.GetKey(KeyCode.S))
        {
            Move(-transform.up);
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-transform.right);
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
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
