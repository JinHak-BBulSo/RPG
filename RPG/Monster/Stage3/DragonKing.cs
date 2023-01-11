using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG.Monster.Stage3
{
    internal class DragonKing : Character
    {
        public DragonKing()
        {
            isIceWeak = true;
            isMonster = true;
            hp = 3000;
            mp = 500;
            this.maxHP = this.hp;
            this.maxMP = this.mp;
            damage = 110;
            jobName = "용왕";
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
                        if (mp < 80) pickNumber = 1;
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
                        Console.Write("용왕의 맹진 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    if (number == 2)
                    {
                        hitDamage = (int)(damage * 1.2f) * 2 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 5;
                        RecoveryMP(hitDamage / 2);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("화염 브레스 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        hitDamage = (int)(damage * 3.5f) - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 50;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("용왕의 겁화 : 전원 피해를 입혔다", hitDamage);

                    }
                    else if (number == 2)
                    {
                        hitDamage = damage * 5 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 80;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("용왕의 힘 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    break;
            }
            UI.HitUI(bravers[target - 1], target);
            Task.Delay(2000).Wait();
        }
    }
}
