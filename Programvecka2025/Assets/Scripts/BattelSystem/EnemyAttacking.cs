using NUnit.Framework;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerTurnUi;
    
    public bool enemysTurn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemysTurn)
        {
            EnemyAttack();
        }
    }

    public void EnemyAttack()
    {
        int whichAttack = Random.Range(0, 4);

        if (whichAttack == 0)
        {
            Attack1();
        }
        if (whichAttack == 1)
        {
            Attack2();
        }
        if (whichAttack == 2)
        {
            Attack3();
        }
        if (whichAttack == 3)
        {
            Attack4();
        }
    }

    void Attack1() 
    {
        AttackPlayer(1.2f, 15);
        EnemyHasAttacked();
    }

    void Attack2()
    {
        AttackPlayer(0.8f, 3);
        EnemyHasAttacked();
    }

    void Attack3()
    {
        AttackPlayer(1.0f, 5);
        EnemyHasAttacked();
    }

    void Attack4()
    {
        AttackPlayer(1.5f, 30);
        EnemyHasAttacked();
    }


    void AttackPlayer(float powerAmount, int missChance)
    {
        if (enemy.GetComponent<Basestats>() != null)
        {
            bool missed = enemy.GetComponent<Basestats>().MissChance(missChance);

            if (missed)
            {
                bool dodged = player.GetComponent<Basestats>().DodgeAttack();

                
                if (!dodged)
                {
                    bool critical = enemy.GetComponent<Basestats>().CriticalHit();
                    int damage = enemy.GetComponent<Basestats>().GetDamage();
                    if (critical)
                    {
                        damage *= 2; // Double damage on critical hit
                    }
                    // Apply power amount multiplier
                    damage = (int)(damage * powerAmount);
                    player.GetComponent<PlayerHealth>().ChangeHealth(-damage);

                }
                else
                {
                    

                    Debug.Log("Player dodged the attack!");

                }
            }
            else
            {
                
                Debug.Log("Enemy missed the attack!");

            }
        }
        else
        {
            Debug.LogError("Player does not have a Basestats component!");

        }
    }

    void EnemyHasAttacked() 
    {
        playerTurnUi.SetActive(true);
        enemysTurn = false;
    }
}
