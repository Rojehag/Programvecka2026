using Assets.Scripts.GameReliant;
using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerQuestManager : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();
    [SerializeField] Basestats basestats;
    [SerializeField] TextMeshProUGUI questText;

    // Update is called once per frame
    void Update()
    {
        print(quests.Count);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseQuestProgress("Soul Collecter", 1);
            ShowQuests();
        }
        
        
    }

    public void IncreaseQuestProgress(string questName, int amount)
    {
        for(int i = 0; i < quests.Count; i++)
        {
            if (quests[i].title == questName && quests[i].IsComplete() == false)
            {
                quests[i].IncreaseProgress(amount);

                if (quests[i].IsComplete())
                {
                    basestats.experiancePoints += quests[i].reward;
                    print("Quest Completed");
                }
            }
        }
    }

    public void AddQuest(Quest quest)
    {
        quests.Add(quest);
    }
    public void ShowQuests()
    {
        
        questText.text = "";
        for(int i = 0; i < quests.Count; i++)
        {
            questText.text += quests[i].title + " " + quests[i].progress + "/" + quests[i].completeAmount + "\n";
        }
    }
}
