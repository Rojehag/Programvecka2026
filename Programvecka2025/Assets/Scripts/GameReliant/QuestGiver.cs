using Assets.Scripts.GameReliant;
using System.Runtime.CompilerServices;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    bool playerIsNearby = false;
    Quest myQuest;
    PlayerQuestManager player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myQuest = new Quest("Demon Hunter", "Kill 1 Demon", 10, 1);
        player = FindFirstObjectByType<PlayerQuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsNearby && Input.GetKeyDown(KeyCode.E))
        {
            player.AddQuest(myQuest);
            print("The Quest Giver gave the player a quest");
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
}
