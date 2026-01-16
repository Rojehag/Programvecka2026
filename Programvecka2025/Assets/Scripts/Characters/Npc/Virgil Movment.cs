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
            
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[0];
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[1];
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            gameObject.GetComponent<SpriteRenderer>().sprite = virgilSprites[2];
        }
        if (Input.GetKey(KeyCode.D))
        {
            
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
