using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monster.Stage2
{
    internal class LowVampire : Character
    {
        public LowVampire()
        {
            isFireWeak = true;
            isMonster = true;
            hp = 900;
            mp = 200;
            this.maxHP = this.hp;
            this.maxMP = this.mp;
            damage = 80;
            jobName = "하위 뱀파이어";
            isWindWeak = true;
        }
        public override void ActionSelect(Player[] bravers)
        {
            UI.ControlChaTextClear();
            UI.TextClear();
            Console.SetCursorPosition(22, 5);
            Console.Write("행동중인 몬스터 : " + jobName);
            bool actionSelctComplete = false;
            while (!actionSelctComplete)
            {
                Random random = new Random();
                UI.Clear();
                int pickNumber = 0;
                if (mp >= 40)
                    pickNumber = random.Next(1, 2 + 1);
                else
                    pickNumber = 1;

                switch (pickNumber)
                {
                    case 1:
                        if (mp >= 20)
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
                }
            }
            turnFinish = true;
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
                        hitDamage = damage - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("하위 뱀파이어의 블러드 볼 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    if (number == 2)
                    {
                        hitDamage = (int)(damage * 1.2f) * 2 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 20;
                        Heal(hitDamage);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("하위 뱀파이어의 흡혈 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Task.Delay(1000).Wait();
                        Console.Write("하위 뱀파이어가 {0}의 체력을 회복했다.", hitDamage);

                    }
                    break;
                case "SKILL":
                    hitDamage = (int)(damage * 3.3f) - bravers[target - 1].Def;
                    bravers[target - 1].HitDamage(hitDamage);
                    mp -= 40;
                    Console.SetCursorPosition(35, 27);
                    Console.Write("하위 뱀파이어의 혈마검 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    break;
            }
            UI.HitUI(bravers[target - 1], target);
            Task.Delay(2000).Wait();
        }
    }
}
