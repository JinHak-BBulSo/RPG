using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Sage : Character
    {
        public Sage()
        {
            this.hp = 150;
            this.mp = 250;
            this.damage = 12;
            this.jobName = "현자";
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