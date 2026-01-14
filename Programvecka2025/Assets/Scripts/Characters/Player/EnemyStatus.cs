using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Characters.Player
{
    public class EnemyStatus
    {
        public string charName;
        public float[] position;
        public GameObject characterGameObject;
        public int level;
        public int health;
        public Component enemy;
    }
}
