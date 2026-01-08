using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]int maxHealth;
    int currentHealth;
    int armorAmount = 0;
   
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            amount = RemoveArmor(amount);
        }

        currentHealth += amount;
    }

    public void AddArmor(int amount)
    {
        armorAmount += amount;
    }

    public int RemoveArmor(int amount)
    {
        while (amount < 0 && armorAmount > 0)
        {
            armorAmount--;
            amount++;
        }
        return amount;
    }

    public virtual void Die()
    {
        currentHealth = 0;
    }


    public int GetCurrentHealth()
    {
        return currentHealth;
    }   
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
