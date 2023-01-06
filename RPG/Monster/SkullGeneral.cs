using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monster
{
    internal class SkullGeneral : Character
    {
        public SkullGeneral()
        {
            this.hp = 300;
            this.mp = 120;
            this.damage = 20;
            this.jobName = "스켈레톤 대장군";
        }
        public override void ActionSelect(Character[] bravers)
        {
            bool actionSelctComplete = false;
            while (!actionSelctComplete)
            {
                Random random = new Random();
                UI.Clear();
                int pickNumber = 0;
                if (this.mp >= 15)
                    pickNumber = random.Next(1, 2 + 1);
                else
                    pickNumber = 1;

                switch (pickNumber)
                {
                    case 1:
                        if (this.mp >= 5)
                            pickNumber = random.Next(1, 2 + 1);
                        else pickNumber = 1;
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "Attack";
                            actionSelctComplete = true;
                        }
                        break;
                    case 2:
                        pickNumber = 1;
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "Skill";
                            actionSelctComplete = true;
                        }
                        break;
                    case 3:
                        continue;
                    case 4:
                        continue;
                }
            }
            this.turnFinish = true;
            ActionStart(selectNumber, selectAction, bravers);
        }

        public override void ActionStart(int number, string action, Character[] bravers)
        {
            Action act = new Action();
            int target = TargetSelect(bravers);

            switch (action)
            {
                case "Attack":
                    if (number == 1)
                    {
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 궁수의 화살 공격 : {0}", this.Damage);
                    }
                    if (number == 2)
                    {

                        this.mp -= 5;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 궁수의 차지샷 : ", (int)(this.Damage * 1.5f));
                    }
                    break;
                case "Skill":
                    this.mp -= 15;
                    Console.SetCursorPosition(35, 27);
                    Console.Write("스켈레톤 궁수의 트리플 에로우 : {0}", this.Damage * 3);
                    break;
            }
            Console.SetCursorPosition(0, 30);
        }
    }
}
