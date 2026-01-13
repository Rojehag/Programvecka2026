using Assets.Scripts.GameReliant;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuestManager : MonoBehaviour
{
    List<Quest> quests = new List<Quest>();
    [SerializeField] Basestats basestats;
    [SerializeField] ExperienceBar experienceBar;
    
    // Update is called once per frame
    void Update()
    {
        print(quests.Count);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IncreaseQuestProgress("Demon Hunter", 1);
        }
        experienceBar.SetExperience(basestats.experiancePoints);
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
}
