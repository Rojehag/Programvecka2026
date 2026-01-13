using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider expSlider;

    public void SetExperience(int Experience) 
    { 
        expSlider.value = Experience;
    }
}
