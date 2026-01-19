using Assets.Scripts.GameReliant;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PlayerAttacking : MonoBehaviour
{
    [SerializeField] GameObject enemy;
   

    [SerializeField] GameObject player;

    [SerializeField] GameObject attacker;

    [SerializeField] GameObject soundController;

    [SerializeField] List<TextMeshProUGUI> damageText = new List<TextMeshProUGUI>();

    [SerializeField] GameObject attackUi; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        damageText[1].SetText("Heavy Attack!");
        damageText[2].SetText("Light Attack!");
        damageText[3].SetText("Medium Attack!");
        damageText[4].SetText("Special Attack!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack1()
    {
        print("Attack1");
        AttackEnemy(1.2f, 15);
        PlayerHasAttacked();
    }
    public void Attack2()
    {
        print("Attack2");
        AttackEnemy(0.8f, 3);
        PlayerHasAttacked();
    }

    public void Attack3()
    {
        print("Attack3");
        AttackEnemy(1.0f, 5);
        PlayerHasAttacked();
    }

    public void Attack4() 
    {
        print("Attack4");
        AttackEnemy(1.5f, 30);
        PlayerHasAttacked();
        
    }


    void AttackEnemy(float PowerAmount, int missChance)
    {
        if (enemy.GetComponent<Basestats>() != null)
        {
            bool missed = player.GetComponent<Basestats>().MissChance(missChance);

            if (missed)
            {
                bool dodged = enemy.GetComponent<Basestats>().DodgeAttack();

                if (!dodged)
                {
                    bool critical = player.GetComponent<Basestats>().CriticalHit();
                    int damage = player.GetComponent<Basestats>().GetDamage();
                    if (critical)
                    {
                        damage *= 2; // Double damage on critical hit
                    }
                    // Apply power amount multiplier
                    damage = (int)(damage * PowerAmount);
                    enemy.GetComponent<EnemyHealth>().ChangeHealth(-damage);

                }
                else
                {
                    damageText[0].SetText("Enemy Dodged!");

                    Debug.Log("Enemy dodged the attack!");

                }
            }
            else
            {
                damageText[0].SetText("You Missed!");
                Debug.Log("Player missed the attack!");

            }
        }
        else
        {
            Debug.LogError("Enemy does not have a Basestats component!");

        }
        

    }

    void PlayerHasAttacked()
    {
        attackUi.SetActive(false);
        damageText[0].SetText("Enemy is Attacking!");
        Invoke(nameof(EnemyAttack), 1.0f);
    }
   
    void EnemyAttack()
    {
        attacker.GetComponent<EnemyAttacking>().EnemyAttack();
    }
}
