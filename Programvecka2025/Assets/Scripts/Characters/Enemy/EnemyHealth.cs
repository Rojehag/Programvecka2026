using UnityEngine;

public class EnemyHealth : Health
{
    
    private void Update()
    {
        // Check if health is zero or below
        if (GetCurrentHealth() <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        // Add enemy death effects here (e.g., play animation, drop loot)
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }
}
