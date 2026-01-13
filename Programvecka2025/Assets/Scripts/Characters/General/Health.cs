using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    int currentHealth = 100;
    int armorAmount = 0;

    private void Start()
    {
        
       currentHealth = gameObject.GetComponent<Basestats>().GetMaxHealth();
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

    
}
