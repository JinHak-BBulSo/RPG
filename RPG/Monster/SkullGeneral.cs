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
            this.hp = 1500;
            this.mp = 250;
            this.damage = 70;
            this.jobName = "스켈레톤 대장군";
        }
        public override void ActionSelect(Player[] bravers)
        {
            UI.ControlChaTextClear();
            UI.TextClear();
            Console.SetCursorPosition(22, 5);
            Console.Write("행동중인 몬스터 : " + this.jobName);
            bool actionSelctComplete = false;
            while (!actionSelctComplete)
            {
                Random random = new Random();
                UI.Clear();
                int pickNumber = 0;
                if (this.mp >= 50)
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
                        pickNumber = random.Next(1, 2 + 1);
                        if (this.mp < 100) pickNumber = 1;
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "SKILL";
                            actionSelctComplete = true;
                        }
                        break;
                }
            }
            this.turnFinish = true;
            ActionStart(selectNumber, selectAction, bravers);
        }

        public override void ActionStart(int number, string action, Player[] bravers)
        {
            int target = 0;
            Action act = new Action(); // 나중에 구현
            if (!bravers[1].IsDie && bravers[1].IsSeraph)
            {
                target = 2;
            }
            else
                target = TargetSelect(bravers);
            int hitDamage = 0;
            UI.TextClear();

            switch (action)
            {
                case "ATTACK":
                    if (number == 1)
                    {
                        hitDamage = this.damage - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 대장군의 참격 : {0}의 피해를 입혔다", hitDamage);
                    }
                    if (number == 2)
                    {
                        hitDamage = this.damage * 2 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        this.mp -= 5;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 대장군의 3연격 : {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        foreach (var item in bravers)
                        {
                            hitDamage = (int)(this.damage * 1.5f) - item.Def;
                            item.HitDamage(hitDamage);
                        } 
                        bravers[target - 1].HitDamage(hitDamage);
                        this.mp -= 50;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("스켈레톤 대장군의 지옥참마도 : 전원 피해를 입혔다", hitDamage);
                        
                    }
                    else if(number == 2)
                    {
                        hitDamage = this.damage * 3 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        this.mp -= 70;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("스켈레톤 대장군의 심장파괴 : {0}에게 {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    break;
            }
            Task.Delay(2000).Wait();
        }
    }
}
