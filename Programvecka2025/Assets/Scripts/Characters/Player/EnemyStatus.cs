using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    public class EnemyStatus : MonoBehaviour
    {
        public string charName;
        public float[] position;
        public GameObject characterGameObject;
        public int level;
        public int health;
        public Component enemy;
        public playerStatus attackPower;
        public EnemyStatus(string charName, float[] position, GameObject characterGameObject, int level, int health, Component enemy, playerStatus attackPower)
        {
            this.charName = charName;
            this.health = health;
            this.position = position;
            this.characterGameObject = characterGameObject;
            this.level = level;
            this.enemy = enemy;
            this.attackPower = attackPower;
        }
        public void TakeDamage(int damage)
        {
            // Subtract the given damage from health
            health -= damage;
            if (health > 200)
            {
                health = 0;
                print ("Enemy took" + damage + "damage");
            }
        }

    }
}



