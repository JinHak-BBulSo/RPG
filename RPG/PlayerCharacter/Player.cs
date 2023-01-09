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
        protected int heal = 0;
        protected int damageUpPotionTurn = 0;
        protected int healUpPotionTurn = 0;
        protected bool isSeraph = false;
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
                            pickNumber = UI.InventoryPointer();
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
                            actionSelectNumber = 0;
                            continue;
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
                this.damage += 15;
            else
                this.damage += 30;
        }
        public void HealUpPotion(int number)
        {
            if (number == 0)
            {
                this.heal += 10;
            }
            else
                this.heal += 20;

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
                hp = maxHP;
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
            isDie = false;
        }
    }
}
