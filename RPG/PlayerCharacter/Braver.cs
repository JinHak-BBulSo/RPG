using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Braver : Player
    {
        int blessingCount = 0;
        int blessingOverlap = 0;
        int originDamage;

        public Braver()
        {
            this.hp = 400;
            this.maxHP = hp;
            this.mp = 200;
            this.maxMP = mp;
            this.def = 15;
            this.damage = 15;
            this.jobName = "용사";
            this.originDamage = this.damage;
            this.actionConsumeMP = new int[2,3]
            {
                { 0, 5, 9 },
                { 20, 30, 50 }
            };
        }

        public override void ActionStart(int number, string action, int target, Character[] monsters)
        {
            Action act = new Action();
            UI.TextClear();
            int hitDamage = 0;
            switch (action)
            {
                case "ATTACK":
                    if(number == 1)
                    {
                        hitDamage = damage;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("용사의 수직베기 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else if(number == 2)
                    {
                        hitDamage = (int)(damage * 1.5f);
                        Console.SetCursorPosition(35, 27);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.Write("용사의 슬래쉬 : {0}의 피해를 입혔다", hitDamage);
                        Console.ForegroundColor = ConsoleColor.Red;
                        act.Slash();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        hitDamage = (int)(damage * 2);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("용사의 더블 슬래쉬 : {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        mp -= actionConsumeMP[1, number - 1];
                        blessingOverlap++;
                        Console.SetCursorPosition(35, 27);
                        Console.Write("영광의 축복 : 2턴 동안 공격력이 1.5배가 된다.");
                        blessingCount = 3;
                        this.damage = (int)(damage * 1.5f);
                    }
                    else if (number == 2)
                    {
                        hitDamage = (int)(damage * 3.5f);
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("성검 : 엑스칼리버 {0}의 피해를 입혔다", hitDamage);
                        Console.ForegroundColor = ConsoleColor.Red;
                        act.Slash();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        hitDamage = (int)(damage * 5.5f);
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("최후의 심판 {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
            }
            if (blessingCount > 0)
            {
                if (blessingOverlap == 2)
                {
                    blessingCount--;
                    damage /= 2;
                }
                else
                {
                    blessingCount--;
                    if (blessingCount == 0) 
                        damage = originDamage;
                }
            }
            if(hitDamage != 0)
            {
                monsters[target - 1].HitDamage(hitDamage);
            }
        }
    }
}
