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

    [SerializeField] GameObject dustParticles;

    [SerializeField] List<Sprite> playerSprites = new List<Sprite>();

    // Reference to the Rigidbody2D component
    Rigidbody2D rigidbody;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        // Get the Rigidbody2D component attached to the player GameObject
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().enabled = false;
        dustParticles.SetActive(false);
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
            dustParticles.SetActive(true);
            dustParticles.transform.rotation = Quaternion.Euler(0, 0, 90);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Up", true);

        }
        if(Input.GetKey(KeyCode.S))
        {
            Move(-transform.up);
            dustParticles.SetActive(true);
            dustParticles.transform.rotation = Quaternion.Euler(0, 0, -90);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Down", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-transform.right);
            dustParticles.SetActive(true);
            dustParticles.transform.rotation = Quaternion.Euler(0, 0, 180);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Left", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(transform.right);
            dustParticles.SetActive(true);
            dustParticles.transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Right", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Up", false);
            GetComponent<Animator>().enabled = false;
            dustParticles.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("Down", false);
            dustParticles.SetActive(false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Left", false);
            dustParticles.SetActive(false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Right", false);
            dustParticles.SetActive(false);
            GetComponent<Animator>().enabled = false;
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
