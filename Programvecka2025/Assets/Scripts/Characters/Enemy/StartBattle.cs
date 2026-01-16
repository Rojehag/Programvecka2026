using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBattle : MonoBehaviour
{
    bool isPlayerInRange = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInRange)
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
        PlayerPrefs.SetFloat("playerx",transform.position.x);
        PlayerPrefs.SetFloat("playery",transform.position.y);
        
        print("Let's start fighting!!!");
        SceneManager.LoadScene(4);
    }
}
