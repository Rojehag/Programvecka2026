using Assets.Scripts.GameReliant;
using System.Collections;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    bool playerIsNearby = false;
    Quest myQuest;
    PlayerQuestManager player;
    int index = 0;
    [SerializeField] GameObject questUi;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myQuest = new Quest("Soul Collecter", "Kill 10 Demon", 100, 10);
        player = FindFirstObjectByType<PlayerQuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsNearby && Input.GetKeyDown(KeyCode.E) && index < 1)
        {
            StartCoroutine(GetQuest());
            index++;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerIsNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsNearby = false;
        }
    }

    public IEnumerator GetQuest()
    {
        player.AddQuest(myQuest);
        print("The Quest Giver gave the player a quest");
        questUi.SetActive(true);
        player.ShowQuests();
        yield return new WaitForSeconds(2);
        questUi.SetActive(false);
    }
}
