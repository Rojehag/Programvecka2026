using Assets.Scripts.Characters.Player;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

// Fix for CS0120 and CS1061:
// - CS0120: You must use an instance of PlayerInteracter, not the type name.
// - CS1061: ScriptableObject does not have a transform. You need a reference to a GameObject or its Transform.
// Assuming you have a reference to the PlayerInteracter instance and its GameObject.

[CreateAssetMenu(fileName = "InteractionManager", menuName = "Scriptable Objects/InteractionManager")]
public class InteractionManager : ScriptableObject
{
    public PlayerInteracter playerInteracter; // Add a reference to the PlayerInteracter instance

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Example: Ensure playerInteracter is assigned before using
        if (playerInteracter == null || playerInteracter.characterGameObject == null)
            return;

        bool isAttacked = false;
        if (playerInteracter.health > 0)
        {
            if (other.tag == "enemy")
            {
                if (!isAttacked)
                {
                    isAttacked = true;
                    setBattleData(other);
                    SceneManager.LoadScene("BattleScene");
                }
            }
        }
    }

    private void setBattleData(Collider2D other)
    {
        // Use the player's GameObject transform to get position
        playerInteracter.position[0] = playerInteracter.characterGameObject.transform.position.x;
        playerInteracter.position[1] = playerInteracter.characterGameObject.transform.position.y;

        // Enemy data setup
        EnemyStatus enemyComponent = other.gameObject.GetComponent<EnemyStatus>();
        if (enemyComponent != null)
        {
            EnemyStatus enemyStatus = enemyComponent;
            if (enemyStatus != null)
            {
                playerInteracter.charName = enemyStatus.charName;
                enemyStatus.charName = playerInteracter.charName;
                enemyStatus.characterGameObject = other.gameObject.transform.GetChild(0).gameObject;
            }
        }
    }
}