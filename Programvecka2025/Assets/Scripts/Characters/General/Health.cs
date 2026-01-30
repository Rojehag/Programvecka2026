using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    protected int currentHealth = 100;
    [SerializeField] protected HealthBar healthBar;

    private void Start()
    {
        
       currentHealth = gameObject.GetComponent<Basestats>().GetMaxHealth();
    }


    // Method to change health
    public void ChangeHealth(int amount)
    {

        // Change current health
        currentHealth += amount;
        print("Damage Dealt!");
        healthBar.SetHealth(GetCurrentHealth(), gameObject.GetComponent<Basestats>().GetMaxHealth());
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
