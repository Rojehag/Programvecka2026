using Unity.VisualScripting;
using UnityEngine;

public class Health 
{
    int maxHealth;
    int currentHealth;
    int armorAmount = 0;
    public Health(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            amount = removeArmor(amount);
        }

        currentHealth += amount;
    }

    public void addArmor(int amount)
    {
        armorAmount += amount;
    }

    public int removeArmor(int amount)
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
