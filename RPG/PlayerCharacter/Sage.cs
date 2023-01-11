using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Sage : Player
    {
        public Sage()
        {
            this.isMonster = false;
            this.hp = 300;
            this.maxHP = hp;
            this.mp = 450;
            this.maxMP = mp;
            this.damage = 25;
            this.jobName = "현자";
            this.def = 10;
            this.originDamage = this.damage;
            this.actionConsumeMP = new int[2, 3]
            {
                { 10, 10, 10 },
                { 50, 50, 50 }
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
                    if (number == 1)
                    {
                        if (monsters[target - 1].IsIceWeak)
                        {
                            hitDamage = (int)(damage * 1.5f);
                        }
                        else
                            hitDamage = damage;
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("아이시클 렌스 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else if (number == 2)
                    {
                        if (monsters[target - 1].IsFireWeak)
                        {
                            hitDamage = (int)(damage * 1.5f);
                        }
                        else
                            hitDamage = damage;
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("파이어 볼 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else
                    {
                        if (monsters[target - 1].IsWindWeak)
                        {
                            hitDamage = (int)(damage * 1.5f);
                        }
                        else
                            hitDamage = damage;
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("윈드 엣지 : {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        if (monsters[target - 1].IsIceWeak)
                        {
                            hitDamage = damage * 5;
                        }
                        else
                            hitDamage = damage * 3;
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("블리자드 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else if (number == 2)
                    {
                        if (monsters[target - 1].IsFireWeak)
                        {
                            hitDamage = damage * 5;
                        }
                        else
                            hitDamage = damage * 3;
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("헬파이어 {0}의 피해를 입혔다", hitDamage);
                    }
                    else
                    {
                        if (monsters[target - 1].IsWindWeak)
                        {
                            hitDamage = damage * 5;
                        }
                        else
                            hitDamage = damage * 3;
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("템페스트 {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
            }
            if (hitDamage != 0)
            {
                UI.HitUI(monsters[target - 1], target);
                monsters[target - 1].HitDamage(hitDamage);
                Task.Delay(1000).Wait();
            }
            PotionBuffCheck();
        }
        public override void LevelUP()
        {
            this.damage += 30;
            this.maxHP += 100;
            this.maxMP += 125;
            this.def += 10;
        }
    }
}