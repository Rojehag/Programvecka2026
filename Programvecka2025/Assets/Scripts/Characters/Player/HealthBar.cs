using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public void SetHealth(int Health, int MaxHealth) 
    { 
        fillImage.fillAmount = Health / MaxHealth;
    }
}
