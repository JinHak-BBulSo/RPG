﻿using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG.Monster.Stage3
{
    internal class DemonKing : Character
    {
        public DemonKing() 
        {
            isIceWeak = true;
            isMonster = true;
            hp = 5000;
            mp = 1000;
            this.maxHP = this.hp;
            this.maxMP = this.mp;
            damage = 125;
            jobName = "마왕";
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
                        if (mp >= 30)
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
                        if (mp < 90) pickNumber = 1;
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
                        Console.Write("마의 숨결 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    if (number == 2)
                    {
                        hitDamage = (int)(damage * 2.3f) * 2 - bravers[target - 1].Def;
                        bravers[target - 1].HitDamage(hitDamage);
                        mp -= 30;
                        RecoveryMP(hitDamage / 2);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("디멘션 블레이드 : {0} {1}의 피해를 입혔다", bravers[target - 1].JobName, hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        foreach (var item in bravers)
                        {
                            hitDamage = (int)(damage * 1.8f) - item.Def;
                            item.HitDamage(hitDamage);
                        }
                        mp -= 50;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("검은 태양 : 전원 피해를 입혔다");

                    }
                    else if (number == 2)
                    {
                        foreach (var item in bravers)
                        {
                            hitDamage = (int)(damage * 3.2f) - item.Def;
                            item.HitDamage(hitDamage);
                        }
                        mp -= 90;
                        Console.SetCursorPosition(26, 27);
                        Console.Write("악의 제전 : 전원 피해를 입혔다");
                    }
                    break;
            }
            UI.HitUI(bravers[target - 1], target);
            Task.Delay(2000).Wait();
        }
    }
}
