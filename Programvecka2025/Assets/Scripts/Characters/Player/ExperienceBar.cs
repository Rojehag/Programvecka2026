using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image fillImage;

    public void SetExperience(int Experience) 
    { 
        fillImage.fillAmount = Experience / 100f;
    }
}
