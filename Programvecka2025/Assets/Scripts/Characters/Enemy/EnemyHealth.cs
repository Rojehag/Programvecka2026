using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    [SerializeField] GameObject player;

    [SerializeField] LevelLoader levelLoader;
    
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
        StartCoroutine(levelLoader.LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        print(SceneManager.GetActiveScene().buildIndex - 1);
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("playerx", 0), PlayerPrefs.GetFloat("playery", 0));
        
    }
}
