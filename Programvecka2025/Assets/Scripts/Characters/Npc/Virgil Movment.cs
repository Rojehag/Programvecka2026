using System.Collections.Generic;
using UnityEngine;

public class VirgilMovment : MonoBehaviour
{
    [SerializeField] GameObject Dante;

    int speed;
    int maxspeed = 5;

    bool danteClose = false;

    Rigidbody2D rigidbody; 

    [SerializeField]List<Sprite> virgilSprites = new List<Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(danteClose)
        {
            speed = 0;
            Vector3 direction = (Dante.transform.position - transform.position).normalized;
            rigidbody.linearVelocity = direction * speed;
        }
        else
        {
            speed = maxspeed;
            Vector3 direction = (Dante.transform.position - transform.position).normalized;
            rigidbody.linearVelocity = direction * speed;
        }


        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Up", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Down", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Left", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetBool("Right", true);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("Up", false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[0];
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("Down", false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[1];
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("Left", false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[2];
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("Right", false);
            GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[3];
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            danteClose = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            danteClose = false;
        }
    }
}
