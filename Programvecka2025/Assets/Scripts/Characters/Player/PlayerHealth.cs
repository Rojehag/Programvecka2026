using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
    private void Update()
    {
        //For testing purposes only
        if(Input.GetKeyDown(KeyCode.K))
        {
            ChangeHealth(-10);
        }

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
}
