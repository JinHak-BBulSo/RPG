using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Saint : Character
    {
        public Saint()
        {
            this.hp = 100;
            this.mp = 300;
            this.damage = 3;
            this.jobName = "성녀";
        }
        
        public override void ActionStart(int number, string action, Character[] monsters)
        {
            Action act = new Action();
            switch (action)
            {
                case "Attack":
                    if (number == 2)
                    {
                        Console.SetCursorPosition(35, 27);
                        Console.Write("전사의 슬래쉬 공격 : ");
                    }
                    break;
                case "Skill":
                    break;
            } 
            Console.SetCursorPosition(0, 30);
        }
    }
}