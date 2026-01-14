using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
   

    private void Start()
    {
        
    }
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
        //Add scene for game over;
        SceneManager.LoadScene(0);
        Debug.Log("Player has died.");
    }

    public override void ChangeHealth(int amount)
    {
        base.ChangeHealth(amount);
        healthBar.SetHealth(GetCurrentHealth());
    }
}
