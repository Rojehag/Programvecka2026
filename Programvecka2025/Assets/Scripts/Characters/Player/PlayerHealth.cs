using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
    
    public override void Die()
    {
        //Add scene for game over;
        //SceneManager.LoadScene()
        Debug.Log("Player has died.");
    }
}
