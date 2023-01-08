using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monster
{
    internal class SkullArchor : Character
    {
        public SkullArchor() 
        {
            this.hp = 70;
            this.mp = 40;
            this.damage = 10;
            this.jobName = "스켈레톤 궁수";
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
                            selectAction = "ATTACK";
                            actionSelctComplete = true;
                        }
                        break;
                    case 2:
                        pickNumber = 1;
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "SKILL";
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
            Action act = new Action(); // 나중에 구현
            int target = TargetSelect(bravers);
            int hitDamage = 0;
            UI.TextClear();

            switch (action)
            {
                case "ATTACK":
                    if (number == 1)
                    {
                        hitDamage = this.damage;
                        bravers[target - 1].HitDamage(hitDamage);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 궁수의 화살 공격 : {0}의 피해를 입혔다", this.Damage);
                    }
                    if (number == 2)
                    {
                        hitDamage = (int)(this.damage * 1.5f);
                        bravers[target - 1].HitDamage(hitDamage);
                        this.mp -= 5;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 궁수의 차지샷 : {0}의 피해를 입혔다", (int)(this.Damage * 1.5f));
                    }
                    break;
                case "SKILL":
                    hitDamage = this.damage * 2;
                    bravers[target - 1].HitDamage(hitDamage);
                    this.mp -= 15;
                    Console.SetCursorPosition(35, 27);
                    Console.Write("스켈레톤 궁수의 트리플 에로우 : {0}", this.Damage * 2);
                    break;
            }
            Task.Delay(2000).Wait();
            Console.SetCursorPosition(0, 30);
        }
    }
}
