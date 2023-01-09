using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Paladin : Player
    {
        private int seraphCount = 0;
        private int seraphOverlap = 0;
        private int sanctuaryCount = 0;

        
        public Paladin()
        {
            this.heal = 15;
            this.hp = 500;
            this.maxHP = hp;
            this.mp = 275;
            this.maxMP = mp;
            this.damage = 7;
            this.def = 20;
            originDef = this.def;
            this.jobName = "팔라딘";
            this.actionConsumeMP = new int[2, 3]
            {
                { 0, 4, 7 },
                { 30, 50, 40 }
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
                        Console.Write("팔라딘의 휘두르기 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else if (number == 2)
                    {
                        hitDamage = (int)(damage * 1.3f);
                        Console.SetCursorPosition(35, 27);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.Write("팔라딘의 십자 베기 : {0}의 피해를 입혔다", hitDamage);
                    }
                    else
                    {
                        hitDamage = (int)(damage * 1.7f);
                        mp -= actionConsumeMP[0, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("팔라딘의 쉴드 어택 : {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
                case "SKILL":
                    if (number == 1)
                    {
                        mp -= actionConsumeMP[1, number - 1];
                        isSeraph = true;
                        seraphCount = 3;
                        this.def = (int)(def * 1.5f);
                        Console.SetCursorPosition(26, 27);
                        Console.Write("세라픽 페더 : 자신의 방어력이 증가한다, 또한 적에게 도발을 시전한다");
                        
                    }
                    else if (number == 2)
                    {
                        mp -= actionConsumeMP[1, number - 1];
                        sanctuaryCount = 2;
                        Console.SetCursorPosition(24, 27);
                        Console.Write("디바인 생츄어리 : 파티원 전체의 체력을 회복하고, 다음턴 방어력이 증가한다", hitDamage);
                        foreach(var item in bravers)
                        {
                            item.Heal(this.heal * 3);
                            item.DefUp((int)(this.originDef / 2));
                        }
                    }
                    else
                    {
                        hitDamage = damage * 4;
                        mp -= actionConsumeMP[1, number - 1];
                        Console.SetCursorPosition(35, 27);
                        Console.Write("저지먼트 콜 {0}의 피해를 입혔다", hitDamage);
                    }
                    break;
            }
            if (seraphCount > 0)
            {
                if (seraphOverlap == 2)
                {
                    seraphCount--;
                    def = (int)(def * 1.5f);
                }
                else
                {
                    seraphCount--;
                    if (seraphCount == 0)
                        def = originDef;
                }
            }

            if(sanctuaryCount > 0)
            {
                sanctuaryCount--;
                if(sanctuaryCount == 0)
                {
                    foreach(var item in bravers)
                    {
                        if (item.JobName == "팔라딘")
                        {
                            this.def -= (int)(originDef / 2);
                        }
                        else
                            item.DefReset();
                    }
                }
            }

            if (hitDamage != 0)
            {
                monsters[target - 1].HitDamage(hitDamage);
            }
        }
    }
}