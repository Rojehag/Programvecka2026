using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;

    public void SetHealth(int Health) 
    { 
        fillImage.fillAmount = Health / 100f;
    }
}
