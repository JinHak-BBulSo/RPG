using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    enum BraverParty : int
    {
        BRAVER = 1, PALADIN = 2, SAGE = 3, SAINT = 4
    }

    internal class Player : Character
    {
        protected int level = 1;
        private int[] expRequire = new int[9]{ 100, 200, 300, 400, 500, 600, 700 ,800, 900 };
        protected int exp = 0;
        public int Exp
        {
            get { return exp; }
            private set { exp = value; }
        }
        protected int heal = 0;
        protected int damageUpPotionTurn = 0;
        protected bool damagePotionUsed = false;
        protected int nowDamageUpPotion = 0;
        public bool DamagePotionUsed
        {
            get { return damagePotionUsed; }
            private set { damagePotionUsed = value; }
        }
        protected int healUpPotionTurn = 0;
        protected bool healUpPotionUsed = false;
        public bool HealUpPotionUsed
        {
            get { return healUpPotionUsed; }
            private set { healUpPotionUsed = value; }
        }
        public int nowHealUpPotion = 0;
        protected bool isSeraph = false;
        protected bool isAvoid = false;
        public bool IsAvoid
        {
            get { return isAvoid; }
            private set { isAvoid = value; }
        }
        public bool IsSeraph
        {
            get { return isSeraph; }
            private set { isSeraph = value; }
        }

        public override void ActionSelect(Player[] bravers, Character[] monsters, int selectCharacterNumber, Inventory inventory)
        {
            Console.SetCursorPosition(22, 5);
            Console.Write("조작중인 캐릭터 : " + this.jobName);
            //플레이어 캐릭터
            int pickNumber = 0;
            int targetNumber = 0;
            int actionSelectNumber = 0;
            bool actionSelctComplete = false;
            int consumeMP = 0;
            bool isBuff = false;

            while (!actionSelctComplete)
            {
                // 행동할 동작 선택
                if (actionSelectNumber == 0)
                {
                    ActionList.PrintActionList();
                    actionSelectNumber = UI.SelectPointer(6);
                }

                // 캐릭터 재선택을 선택한 경우 리셋
                if (actionSelectNumber == 5)
                {
                    actionSelectNumber = 0;
                    selectCharacterNumber = 0;
                    return;
                }

                if (actionSelectNumber == 6)
                {
                    this.turnFinish = true;
                    return;
                }

                // 동작의 상세 선택
                if (targetNumber == 0)
                {
                    switch (actionSelectNumber)
                    {
                        case 1:
                            ActionList.PrintAttackList(bravers[selectCharacterNumber - 1].JobName);
                            pickNumber = UI.SelectPointer(4);
                            if (pickNumber < 4)
                            {
                                selectNumber = pickNumber;
                                selectAction = "ATTACK";
                            }
                            else
                            {
                                actionSelectNumber = 0;
                                continue;
                            } // 뒤로를 선택한 경우
                            break;
                        case 2:
                            ActionList.PrintSkillList(bravers[selectCharacterNumber - 1].JobName);
                            pickNumber = UI.SelectPointer(4);
                            if (pickNumber < 4)
                            {
                                selectNumber = pickNumber;
                                selectAction = "SKILL";
                                if (
                                    (selectCharacterNumber == (int)BraverParty.BRAVER && selectNumber == 1) ||
                                    (selectCharacterNumber == (int)BraverParty.PALADIN && (selectNumber == 1 || selectNumber == 2)) ||
                                    selectCharacterNumber == (int)BraverParty.SAINT
                                    )
                                {
                                    isBuff = true;
                                }
                            }
                            else
                            {
                                actionSelectNumber = 0;
                                continue;
                            } // 뒤로를 선택한 경우
                            break;
                        case 3:
                            inventory.PrintInventory();
                            pickNumber = UI.InventoryPointer(inventory);
                            if (pickNumber == 9)
                            {
                                actionSelectNumber = 0;
                                continue;
                            }
                            else
                            {
                                inventory.UseItem(bravers, pickNumber);
                                UI.CharacterSetting(bravers);
                                continue;
                            }
                        case 4:
                            this.isAvoid = true;
                            return;
                    }
                }
                consumeMP = actionConsumeMP[(int)Action_.ATTACK, pickNumber - 1];
                // 공격할 대상 선택
                if (!isBuff)
                {
                    UI.PrintMonsterList(monsters);
                    targetNumber = UI.SelectPointer(5);
                    if (targetNumber == 5 || monsters[targetNumber - 1].IsDie)
                    {
                        if (targetNumber == 5)
                        {
                            targetNumber = 0;
                            continue;
                        }
                        else
                        {
                            UI.TextClear();
                            Console.SetCursorPosition(35, 27);
                            Console.Write("선택한 몬스터 {0}은 이미 사망했습니다.", monsters[targetNumber - 1].JobName);
                            continue;
                        }
                    }
                }

                if (this.mp - consumeMP < 0)
                {
                    Console.WriteLine("MP가 부족해 사용할 수 없습니다.");
                    pickNumber = 0;
                    continue;
                }
                actionSelctComplete = true;
            }
            bravers[selectCharacterNumber - 1].TurnOver();
            if (selectCharacterNumber == (int)BraverParty.BRAVER || selectCharacterNumber == (int)BraverParty.SAGE)
            {
                ActionStart(selectNumber, selectAction, targetNumber, monsters);
                
            }
            else
            {
                ActionStart(selectNumber, selectAction, targetNumber, bravers, monsters);
            }
             
        }
        public void DamageUpPotion(int number)
        {
            if (number == 0)
            {
                nowDamageUpPotion = 15;
                this.damage += 15;
            }
            else
            {
                nowDamageUpPotion = 30;
                this.damage += 30;
            }
            damageUpPotionTurn = 2;
            damagePotionUsed = true;
        }
        public void HealUpPotion(int number)
        {
            if (number == 0)
            {
                nowHealUpPotion = 10;
                this.heal += 10;
            }
            else
            {
                nowHealUpPotion = 20;
                this.heal += 20;
            }
            healUpPotionTurn = 2;
            healUpPotionUsed = true;
        }
        public void PotionBuffCheck()
        {
            if (damagePotionUsed)
            {
                damageUpPotionTurn--;
                if(damageUpPotionTurn == 0)
                {
                    this.damage -= nowDamageUpPotion;
                    damagePotionUsed = false;
                    nowDamageUpPotion = 0;
                }
            }
            if (healUpPotionUsed)
            {
                healUpPotionTurn--;
                if(healUpPotionTurn == 0)
                {
                    this.heal -= nowHealUpPotion;
                    healUpPotionUsed = false;
                    nowHealUpPotion = 0;
                }
            }
        }
        public void MPPotion(int number)
        {
            if (number == 0)
            {
                this.mp += 50;
            }
            else
                this.mp += 120;

            if (this.mp > maxMP)
                this.mp = maxMP;
        }

        public void Heal(int heal)
        {
            this.hp += heal;
            if (hp > this.maxHP)
            {
                this.hp = maxHP;
            }
        }

        public void DefUp(int buffDef)
        {
            this.def += buffDef;
        }
        public void DefReset()
        {
            this.def = originDef;
        }
        public void Revive()
        {
            this.isDie = false;
        }

        public virtual void Recall()
        {
            this.isDie = false;
            this.hp = this.maxHP;
            this.mp = this.maxMP;
            this.def = this.originDef;
            this.damageUpPotionTurn = 0;
            this.healUpPotionTurn = 0;
            this.isSeraph = false;
            this.damage = this.originDamage;
            this.turnFinish = false;
            this.isAvoid = false;
        }
        public void GetExp(int exp)
        {
            if (this.level == 10) return;
            this.exp += exp;
            if(this.exp >= expRequire[this.level - 1])
            {
                this.exp -= expRequire[this.level - 1];
                Console.SetCursorPosition(35, 27);
                Console.Write("{0} 레벨업을 했다.", this.jobName);
            }
            this.level++;
            if (level == 10) this.exp = 0;
        }
        public virtual void LevelUP()
        {
            /* override using */
        }

        public void AutoMPRecovery()
        {
            this.mp += 15;
            if(mp > maxMP)
            {
                mp = maxMP;
            }
        }
    }
}
