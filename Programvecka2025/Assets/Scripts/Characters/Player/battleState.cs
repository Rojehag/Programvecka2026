using Assets.Scripts.Characters.Player;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class battleState : MonoBehaviour


{
    
    public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOST }
    private GameObject enemy;
    private GameObject player;

    public Transform enemyBattlePosition;
    public Transform playerBattlePosition;

    public playerStatus playerStatus;
    public EnemyStatus enemyStatus;

    private BattleState battlEState;
    private bool hasClicked = true;

    void Start()
    {
        {
            battlEState = BattleState.START;
            StartCoroutine(BeginBattle());
        }
    }
    IEnumerator BeginBattle()
    {
        // setup battle scene
        // instantiating player and enemy gameobjects
        player = Instantiate(playerStatus.characterGameObject, playerBattlePosition);
        enemy = Instantiate(enemyStatus.characterGameObject, enemyBattlePosition);
        yield return new WaitForSeconds(1);
        battlEState = BattleState.PLAYERTURN;
        yield return StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerTurn()
    {

        // stating it's player's turn here
        yield return new WaitForSeconds(1);


        // so that player can click on 'attack' button    
        hasClicked = false;
    }
    public void OnAttackButtonPress(BaseEventData eventData)
    {
        EventTriggerType eventType = EventTriggerType.PointerClick;
        EventTrigger evTrigg = gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry ClickEvent = new EventTrigger.Entry();
        // don't allow player to click on 'attack'
        // button if it's not his turn!
        if (battlEState != BattleState.PLAYERTURN)
            return;

        // allow only a single action per turn
        if (!hasClicked)
        {
            StartCoroutine(PlayerAttack());
            // Move the PlayerAttack coroutine outside of EndBattle and ensure proper closing brackets

            IEnumerator PlayerAttack()
            {
                yield return new WaitForSeconds(2);

                if (enemyStatus.health <= 0)
                {
                    battlEState = BattleState.WIN;
                    yield return StartCoroutine(EndBattle());
                }
                else
                {
                    battlEState = BattleState.ENEMYTURN;
                    yield return StartCoroutine(EnemyTurn());
                }
            }

            IEnumerator EnemyTurn()
            {
                yield return new WaitForSeconds(2);

                if (playerStatus.health <= 0)
                {
                    battlEState = BattleState.LOST;
                    yield return StartCoroutine(EndBattle());
                }
                else
                {
                    battlEState = BattleState.PLAYERTURN;
                    yield return StartCoroutine(PlayerTurn());
                }
            }

           
        }

    }
    IEnumerator EndBattle()
    {
        // check if we won
        if (battlEState == BattleState.WIN)
        {

            yield return new WaitForSeconds(1);

        }

        else if (battlEState == BattleState.LOST)
        {

            yield return new WaitForSeconds(1);
        }
        IEnumerator PlayerAttack()
        {



            yield return new WaitForSeconds(2);

            if (enemyStatus.health <= 0)
            {
                // if the enemy health drops to 0 
                // we won!
                battlEState = BattleState.WIN;
                yield return StartCoroutine(EndBattle());
            }
            else
            {
                // if the enemy health is still
                // above 0 when the turn finishes
                // it's enemy's turn!
                battlEState = BattleState.ENEMYTURN;
                yield return StartCoroutine(EnemyTurn());
            }
            IEnumerator EnemyTurn()
            {


                yield return new WaitForSeconds(2);

                if (playerStatus.health <= 0)
                {
                    // if the player health drops to 0 
                    // we have lost the battle...
                    battlEState = BattleState.LOST;
                    yield return StartCoroutine(EndBattle());
                }
                else
                {
                    // if the player health is still
                    // above 0 when the turn finishes
                    // it's our turn again!
                    battlEState = BattleState.PLAYERTURN;
                    yield return StartCoroutine(PlayerTurn());

                    

                    
                }

            }
        }
        
    } 
    
}
