using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.PlayerCharacter
{
    internal class Paladin : Character
    {
        public Paladin()
        {
            this.hp = 275;
            this.mp = 125;
            this.damage = 7;
            this.jobName = "팔라딘";
        }
        public override void ActionSelect(Character[] monsters)
        {
            bool actionSelctComplete = false;
            while (!actionSelctComplete)
            {
                UI.Clear();
                int pickNumber = 0;
                ActionList.PrintActionList();
                pickNumber = UI.SelectPointer(4);
                UI.Clear();
                switch (pickNumber)
                {
                    case 1:
                        ActionList.PrintAttackList(jobName);
                        pickNumber = UI.SelectPointer(4);
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "Attack";
                            actionSelctComplete = true;
                        }
                        break;
                    case 2:
                        ActionList.PrintSkillList(jobName);
                        pickNumber = UI.SelectPointer(4);
                        if (pickNumber < 3)
                        {
                            selectNumber = pickNumber;
                            selectAction = "Skill";
                            actionSelctComplete = true;
                        }
                        break;
                    case 3:
                        continue;
                    case 4:
                        continue;
                }
            }
            this.turnFinish = true;
            ActionStart(selectNumber, selectAction, monsters);
        }

        public override void ActionStart(int number, string action, Character[] monsters)
        {
            Action act = new Action();
            switch (action)
            {
                case "Attack":
                    if (number == 2)
                    {
                        Console.SetCursorPosition(35, 27);
                        Console.Write("전사의 슬래쉬 공격 : ");
                    }
                    break;
                case "Skill":
                    break;
            }
            Console.SetCursorPosition(0, 30);
        }
    }
}