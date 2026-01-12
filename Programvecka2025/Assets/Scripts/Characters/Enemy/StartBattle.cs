using UnityEngine;

public class StartBattle : MonoBehaviour
{
    bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerInRange)
        {
            StartFight();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isPlayerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isPlayerInRange = false;
    }

    void StartFight()
    {
        print("Let's start fighting!!!");
        //Switch to fighting scene!
    }
}
