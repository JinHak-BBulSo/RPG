using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Character
    {
        public enum Action_
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
        protected int maxHP;

        protected int mp;
        public int Mp
        {
            get { return mp; }
            private set { mp = value; }
        }
        protected int maxMP;
        protected int[,] actionConsumeMP;

        protected int damage;
        public int Damage
        {
            get { return damage; }
            private set { damage = value; }
        }
        protected int originDamage;

        protected int def;
        protected int originDef;
        public int Def
        {
            get { return def; }
            private set { def = value; }
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
        public bool IsMonster
        {
            get { return isMonster; }
            private set { isMonster = value; }
        }
        protected bool isFireWeak = false;
        public bool IsFireWeak
        {
            get { return isFireWeak; }
            private set { isFireWeak = value; }
        }
        protected bool isWindWeak = false;
        public bool IsWindWeak
        {
            get { return isWindWeak; }
            private set { isWindWeak = value; }
        }
        protected bool isIceWeak = false;
        public bool IsIceWeak
        {
            get { return isIceWeak; }
            private set { IsIceWeak = value; }
        }     

        // 몬스터
        public virtual void ActionSelect(Player[] bravers)
        {

        }

        // 플레이어 캐릭터
        public virtual void ActionSelect(Player[] bravers, Character[] monsters, int selectCharacterNumber, Inventory inventory)
        {
            /* override using */
        }

        // 스킬의 종류가 전부 다르기에 오버라이딩 해서 구현

        // 몬스터용
        public virtual void ActionStart(int number, string action, Player[] bravers)
        {
            /* override using */
        }

        // 플레이어 용사, 현자 사용
        public virtual void ActionStart(int number, string action, int target, Character[] characters)
        {
            /* override using */
        }

        // 플레이어 팔라딘, 성녀 사용
        public virtual void ActionStart(int number, string action, int target, Player[] bravers, Character[] monsters)
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
                if (random.Next(1, 100 + 1) > 70)
                    targetNumber = random.Next(3, 4 + 1); // 후열 공격
                else targetNumber = random.Next(1, 2 + 1); // 전열 공격
                
                if (characters[targetNumber - 1].isDie) continue;
                else return targetNumber;
            }
        }
        // 턴종료
        public void TurnOver()
        {
            this.turnFinish = true;
        }
        // 턴리셋 -> 새로운턴의 시작
        public void TurnReset()
        {
            this.turnFinish = false;
        }
        // 데미지 적용
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
    }
}
