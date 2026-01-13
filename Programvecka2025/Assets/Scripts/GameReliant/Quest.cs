using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.GameReliant
{
    public class Quest
    {
        public string title;
        string description;
        public int reward;

        int progress;
        int completeAmount;

        public Quest(string title, string description, int reward, int completeAmount)
        {
            this.title = title;
            this.description = description;
            this.reward = reward;
            this.completeAmount = completeAmount;
            this.progress = 0;
        }

        public void IncreaseProgress(int amount)
        {
            progress += amount;
        }

        public bool IsComplete()
        {
            return progress >= completeAmount;
        }
    }
}
