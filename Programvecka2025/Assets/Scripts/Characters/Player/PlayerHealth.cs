using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
   

    private void Start()
    {
        
        transform.position = new Vector3(PlayerPrefs.GetFloat("playerx", 0), PlayerPrefs.GetFloat("playery", 0),-1);
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

   
}
