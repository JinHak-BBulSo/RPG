using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Monster.Stage2
{
    internal class HighVampire : Character
    {
        public HighVampire()
        {
            isFireWeak = true;
            isMonster = true;
            hp = 1200;
            mp = 300;
            this.maxHP = this.hp;
            this.maxMP = this.mp;
            damage = 85;
            jobName = "상위 뱀파이어";
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
                if (mp >= 50)
                    pickNumber = random.Next(1, 2 + 1);
                else
                    pickNumber = 1;

                switch (pickNumber)
                {
                    case 1:
                        if (mp >= 5)
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
                        if (mp < 100) pickNumber = 1;
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
                        Console.Write("고위 뱀파이어의 블러드 샷 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    if (number == 2)
                    {
                        hitDamage = (int)(damage * 1.2f) * 2 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 30;
                        RecoveryMP(hitDamage / 2);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("고위 뱀파이어의 에너지 드레인 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Task.Delay(1000).Wait();
                        Console.Write("고위 뱀파이어가 {0}의 마나를 회복했다.", hitDamage / 2);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        foreach (var item in bravers)
                        {
                            hitDamage = (int)(damage * 1.5f) - item.Def;
                            item.HitDamage(hitDamage);
                        }
                        mp -= 50;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("고위 뱀파이어의 블러드 레인 : 전원 피해를 입혔다", hitDamage);

                    }
                    else if (number == 2)
                    {
                        hitDamage = damage * 3 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 100;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("고위 뱀파이어의 블러드 스트림 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    break;
            }
            UI.HitUI(bravers[target - 1], target);
            Task.Delay(2000).Wait();
        }
    }
}
