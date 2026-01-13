using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    internal class EnemyStatus
    {
       
        public string charName;
        public float[] position = new float[2];
        public GameObject characterGameObject;
        public int level;
        public int health;
        public Component enemy;

        public EnemyStatus(string charName, float[] position, GameObject characterGameObject, int level, int health, Component enemy)
        {
            this.charName = charName;
            this.health = health;
            this.position = position;
            this.characterGameObject = characterGameObject;
            this.level = level;
            this.enemy = enemy;
            
        }
    }
}
