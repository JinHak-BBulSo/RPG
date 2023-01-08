using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Character
    {
        enum Action_
        {
            ATTACK, SKILL
        }

        // 턴 완료 체크
        protected bool turnFinish = false;
        public bool TurnFinish
        {
            get { return turnFinish; }
            private set { turnFinish = value; }
        }

        // 선택한 액션 상세 번호
        protected int selectNumber;

        // 공격 or 스킬 or 아이템 등 액션의 분류
        protected string selectAction;
        protected int hp;
        public int Hp
        {
            get { return hp; }
            private set { hp = value; }
        }

        protected int mp;
        public int Mp
        {
            get { return mp; }
            private set { mp = value; }
        }
        protected int[,] actionConsumeMP;

        protected int damage;
        public int Damage
        {
            get { return damage; }
            private set { damage = value; }
        }
        
        // 직업 or 몬스터 명
        protected string jobName;
        public string JobName
        {
            get { return jobName; }
            private set
            { jobName = value; }
        }

        // 죽었는가?
        protected bool isDie = false;
        public bool IsDie
        {
            get { return isDie; }
            private set { isDie = value; }
        }

        // 몬스터인가?
        protected bool isMonster = false;

        // 몬스터
        public virtual void ActionSelect(Character[] bravers)
        {

        }

        // 플레이어 캐릭터
        public virtual void ActionSelect(Character[] bravers, Character[] monsters)
        {
            //플레이어 캐릭터
            int pickNumber = 0;
            int targetNumber = 0;
            int actionSelectNumber = 0;
            int selectCharacterNumber = 0;
            bool actionSelctComplete = false;
            int consumeMP = 0;

            while (!actionSelctComplete)
            {
                // 행동할 캐릭터 선택
                if (selectCharacterNumber == 0)
                {
                    UI.PrintCharacterList();
                    selectCharacterNumber = UI.SelectPointer(4);
                    if (bravers[selectCharacterNumber - 1].TurnFinish)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("{0}은 이미 행동을 마쳤습니다.", bravers[selectCharacterNumber - 1].jobName);
                        selectCharacterNumber = 0;
                        continue;
                    }
                    else if(bravers[selectCharacterNumber - 1].IsDie)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("{0}은 현재 전투 불능입니다.", bravers[selectCharacterNumber - 1].jobName);
                        selectCharacterNumber = 0;
                        continue;
                    }
                }
                
                // 행동할 동작 선택
                if (actionSelectNumber == 0)
                {
                    ActionList.PrintActionList();
                    actionSelectNumber = UI.SelectPointer(5);
                }

                // 캐릭터 재선택을 선택한 경우 리셋
                if (actionSelectNumber == 5)
                {
                    actionSelectNumber = 0;
                    selectCharacterNumber = 0;
                    continue;
                }

                // 동작의 상세 선택
                if (targetNumber == 0)
                {
                    switch (actionSelectNumber)
                    {
                        case 1:
                            ActionList.PrintAttackList(bravers[selectCharacterNumber - 1].jobName);
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
                            ActionList.PrintSkillList(bravers[selectCharacterNumber - 1].jobName);
                            pickNumber = UI.SelectPointer(4);
                            if (pickNumber < 4)
                            {
                                selectNumber = pickNumber;
                                selectAction = "SKILL";
                            }
                            else
                            {
                                actionSelectNumber = 0;
                                continue;
                            } // 동작은 선택한 경우
                            break;
                        case 3:
                            actionSelectNumber = 0;
                            continue;
                        case 4:
                            actionSelectNumber = 0;
                            continue;
                    }
                }
                consumeMP = actionConsumeMP[(int)Action_.ATTACK, pickNumber - 1];
                // 공격할 대상 선택
                UI.PrintMonsterList(monsters);
                targetNumber = UI.SelectPointer(5);
                if (targetNumber == 5 || monsters[targetNumber - 1].isDie)
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
                        Console.Write("선택한 몬스터 {0}은 이미 사망했습니다.", monsters[targetNumber - 1].jobName);
                        continue;
                    }
                }
                if(this.mp - consumeMP < 0)
                {
                    Console.WriteLine("MP가 부족해 사용할 수 없습니다.");
                    pickNumber = 0;
                    continue;
                }
                actionSelctComplete = true;
            }
            this.turnFinish = true;
            ActionStart(selectNumber, selectAction, targetNumber, monsters);
        }

        // 스킬의 종류가 전부 다르기에 오버라이딩 해서 구현
        // 몬스터용
        public virtual void ActionStart(int number, string action, Character[] characters)
        {
            /* override using */
        }

        // 플레이어용
        public virtual void ActionStart(int number, string action, int target, Character[] characters)
        {
            /* override using */
        }
        // 공격할 대상 선택
        protected int TargetSelect(Character[] characters)
        {
            int targetNumber = 0;
            Random random = new Random();
            
            while (true)
            {
                targetNumber = random.Next(1, 4 + 1);
                if (characters[targetNumber - 1].isDie) continue;
                else return targetNumber;
            }
        }

        public void TurnReset()
        {
            this.turnFinish = false;
        }

        public void HitDamage(int damage)
        {
            this.hp -= damage;
            if(this.hp <= 0)
            {
                this.hp = 0;
                this.mp = 0;
                this.turnFinish = true;
                this.isDie = true;
            }
        }

        public void Heal(int heal)
        {
            this.hp += heal;
        }
    }
}
