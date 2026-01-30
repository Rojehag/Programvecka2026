using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image fillImage;
    [SerializeField] GameObject player;
    public void SetExperience(int Experience, int nextLevelAmount) 
    { 
        fillImage.fillAmount = Experience / nextLevelAmount;

        if (Experience >= nextLevelAmount)
        {

            Experience -= nextLevelAmount; // Subtract the required experience for level up
            player.GetComponent<Basestats>().BuffStats(); // You can add additional level-up effects here (e.g., increase player stats)
                                           
            fillImage.fillAmount = Experience / nextLevelAmount; // Reset experience bar
        }
    }
}
