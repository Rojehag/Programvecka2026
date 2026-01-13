using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetHealth(int Health) 
    { 
        healthSlider.value = Health;
    }
}
