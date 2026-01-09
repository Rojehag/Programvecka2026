using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    int maxHealth = 100;
    int currentHealth;
    int armorAmount = 0;

    private void Start()
    {
        // Initialize current health to max health at the start
       // currentHealth = gameObject.Basestats;
    }


    // Method to change health
    public void ChangeHealth(int amount)
    {
        // If amount is negative, remove armor first
        if (amount < 0)
        {
            amount = RemoveArmor(amount);
        }

        // Change current health
        currentHealth += amount;
    }

    // Method to add armor
    public void AddArmor(int amount)
    {
        armorAmount += amount;
    }

    // Method to remove armor
    public int RemoveArmor(int amount)
    {
        while (amount < 0 && armorAmount > 0)
        {
            armorAmount--;
            amount++;
        }
        return amount;
    }

    // Virtual method to handle death, can be overridden by subclasses
    public virtual void Die()
    {
        
    }

    // Getter for current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Getter for max health
    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
