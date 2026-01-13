using UnityEngine;

public class Basestats: MonoBehaviour
{
    // Base Stats
    [SerializeField] int maxHealth;
    [SerializeField] int damage;
    [SerializeField] int attackSpeed;

    // Secondary Stats
    [SerializeField] int criticalChance = 10;
    [SerializeField] int dodegeChance = 20;
    public int experiancePoints;

    // Level Buff Multiplier
    [SerializeField] float levelBuffMultipier;

    public bool DodgeAttack()
    {
        // Generate a random number between 0 and 100
        int dodgeRoll = Random.Range(0, dodegeChance);
        // Check if the roll is less than the dodge chance
        if (dodgeRoll == 1)
        {
            return true; // Attack is dodged
        }
        else
        {
            return false; // Attack hits
        }
    }

    public bool CriticalHit()
    {
        // Generate a random number between 0 and 100
        int critRoll = Random.Range(0, criticalChance);
        // Check if the roll is less than the critical chance
        if (critRoll == 1)
        {
            return true; // Critical hit
        }
        else
        {
            return false; // Normal hit
        }
    }


    // Method to buff stats based on level multiplier
    public void  BuffStats()
    {
        // Apply level buff multiplier to base stats
        maxHealth = maxHealth * (int)levelBuffMultipier;
        damage = damage * (int)levelBuffMultipier;
        attackSpeed = attackSpeed * (int)levelBuffMultipier;

    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
