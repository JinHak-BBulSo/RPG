﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Saint : Player
    {
        public Saint()
        {
            this.heal = 30;
            this.hp = 300;
            this.maxHP = hp;
            this.mp = 450;
            this.maxMP = mp;
            this.def = 10;
            this.damage = 3;
            this.jobName = "성녀";
            this.actionConsumeMP = new int[2, 3]
            {
                { 0, 5, 7 },
                { 20, 50, 100 }
            };
        }

        public override void ActionStart(int number, string action, int target, Player[] bravers, Character[] monsters)
        {
            Action act = new Action();
            UI.TextClear();
            int hitDamage = 0;
            switch (action)
            {
                case "ATTACK":
                    if (number == 1)
                    {
                        hitDamage = damage;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("메이스 어택 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else if (number == 2)
                    {
                        hitDamage = (int)(damage * 1.5f);
                        Console.SetCursorPosition(35, 27);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.Write("세인트 볼 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else
                    {
                        hitDamage = (int)(damage * 2);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("크로스 라이트 : {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        int healTarget = BuffCharacterSelect(bravers, number);
                        mp -= actionConsumeMP[1, number - 1];
                        int healAmount = this.heal * 2;
                        bravers[healTarget - 1].Heal(healAmount);
                        Console.SetCursorPosition(35, 27);
                        Console.Write("힐 : {0}의 체력을 {1} 회복했다", bravers[healTarget - 1].JobName, healAmount);
                    }
                    else if (number == 2)
                    {
                        int healAmount = (int)(this.heal * 1.5f);
                        foreach (var item in bravers)
                        {
                            
                            item.Heal(healAmount);

                        }
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("미라클 샤인 : 파티원 전체의 체력을 {0} 회복", healAmount);
                    }
                    else
                    {
                        int ReviveTarget = BuffCharacterSelect(bravers, number);
                        bravers[ReviveTarget - 1].Revive();
                        bravers[ReviveTarget].Heal(heal * 3);
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("리저렉션 : 대상을 부활시킨다", hitDamage);
                    }
                    break;
            }
            if (hitDamage != 0)
            {
                monsters[target - 1].HitDamage(hitDamage);
            }
        }

        public int BuffCharacterSelect(Player[] bravers, int selectNumber)
        {
            int selectCharacterNumber = 0;
            UI.ControlChaTextClear();

            if (selectNumber == 1)
            {
                while (selectCharacterNumber == 0)
                {
                    UI.PrintCharacterList();
                    selectCharacterNumber = UI.SelectPointer(4);

                    if (bravers[selectCharacterNumber - 1].IsDie)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("{0}은 현재 전투 불능입니다.", bravers[selectCharacterNumber - 1].JobName);
                        selectCharacterNumber = 0;
                        continue;
                    }
                }
            }
            else
            {
                while (selectCharacterNumber == 0)
                {
                    UI.PrintCharacterList();
                    selectCharacterNumber = UI.SelectPointer(4);

                    if (!bravers[selectCharacterNumber - 1].IsDie)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("{0}은 현재 생존해 있입니다.", bravers[selectCharacterNumber - 1].JobName);
                        selectCharacterNumber = 0;
                        continue;
                    }
                }
            }

            return selectCharacterNumber;
        }
    }
}