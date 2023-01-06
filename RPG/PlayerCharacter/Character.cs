using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Character
    {
        protected bool turnFinish = false;
        public bool TurnFinish
        {
            get { return turnFinish; }
            private set { turnFinish = value; }
        }
        protected int selectNumber;
        protected string selectAction;
        protected int hp;
        public int Hp
        {
            get { return hp; }
            private set { hp = value; }
        }

        protected int mp;
        public int Mp
        {
            get { return mp; }
            private set { mp = value; }
        }

        protected int damage;
        public int Damage
        {
            get { return damage; }
            private set { damage = value; }
        }
        protected string jobName;
        public string JobName
        {
            get { return jobName; }
            private set
            { jobName = value; }
        }
        protected bool isDie = false;
        public bool IsDie
        {
            get { return isDie; }
            private set { isDie = value; }
        }

        protected bool isMonster = false;
        public virtual void ActionSelect(Character[] characters)
        {
            /* override using */
        }

        public virtual void ActionStart(int number, string action, Character[] characters)
        {
            /* override using */
        }

        protected int TargetSelect(Character[] characters)
        {
            int targetNumber = 0;
            Random random = new Random();
            
            while (true)
            {
                targetNumber = random.Next(0, 3 + 1);
                if (characters[targetNumber].isDie) continue;
                else return targetNumber;
            }
        }

        public void HitDamage()
        {

        }
    }
}
