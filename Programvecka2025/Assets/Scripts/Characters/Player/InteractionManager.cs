using Assets.Scripts.Characters.Player;
using JetBrains.Annotations;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



[CreateAssetMenu(fileName = "InteractionManager", menuName = "Scriptable Objects/InteractionManager")]
public class InteractionManager : MonoBehaviour
{
    public PlayerInteracter playerInteracter; // Add a reference to the PlayerInteracter instance

    public void OnTriggerEnter2D(Collider2D other)
    {
        // kollar om spelarens interacter och dess gameobject inte är null  
        if (playerInteracter == null || playerInteracter.characterGameObject == null)
            return;
        // Kollar om spelaren har hälsa kvar och om den kolliderar med en fiende
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
    // Sätter upp data för striden mellan spelaren och fienden
    private void setBattleData(Collider2D other)
    {
        // Sätter spelarens position
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
        

         IEnumerator EnemyTurn()
        {
            // as before, decrease playerhealth by a fixed
            // amount of 10. You probably want to have some
            // more complex logic here.
            playerStatus.health(playerStatus, 10);

            // play attack animation by triggering
            // it inside the enemy animator
            EnemyStatus.GetComponent<Animator>().SetTrigger("Attack");

            yield return new WaitForSeconds(2);

            if (playerStatus.health <= 0)
            {
                // if the player health drops to 0 
                // we have lost the battle...
                battleState = BattleState.LOST;
                yield return StartCoroutine(EndBattle());
            }
            else
            {
                // if the player health is still
                // above 0 when the turn finishes
                // it's our turn again!
                battleState = BattleState.PLAYERTURN;
                yield return StartCoroutine(PlayerTurn());
            }
        }
    }
}