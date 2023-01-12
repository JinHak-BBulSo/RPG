using RPG.Monster.Stage1;
using RPG.Monster.Stage2;
using RPG.Monster.Stage3;
using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Stage
    {
        private bool stage1Clear = false;
        public bool Stage1Clear
        {
            get { return stage1Clear; }
            private set { stage1Clear = value; }
        }
        private bool stage2Clear = false;
        public bool Stage2Clear
        {
            get { return stage2Clear; }
            private set { stage2Clear = value; }
        }
        private bool stage3Clear = false;
        public bool Stage3Clear
        {
            get { return stage3Clear; }
            private set { stage3Clear = value; }
        }

        public void Stage1Start(Player[] bravers, Inventory inventory)
        {
            bool wave1Clear = false;
            bool wave2Clear = false;
            bool wave3Clear = false;

            SkullArchor skullArchor = new SkullArchor();
            SkullArchor skullArchor2 = new SkullArchor();
            SkullWarrior skullWarrior = new SkullWarrior();
            SkullWarrior skullWarrior2 = new SkullWarrior();
            SkullKnight skullKnight = new SkullKnight();
            SkullKnight skullKnight2 = new SkullKnight();
            SkullGeneral skullGeneral = new SkullGeneral();

            Character[] monsters = new Character[4] { skullArchor, skullArchor2, skullWarrior, skullWarrior2 };

            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);

            wave1Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave1Clear)
            {
                foreach(Player player in bravers)
                {
                    player.GetExp(25);
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(1000);

                skullArchor = new SkullArchor();
                skullWarrior = new SkullWarrior();
                monsters[0] = skullKnight;
                monsters[1] = skullKnight2;
                monsters[2] = skullArchor;
                monsters[3] = skullWarrior;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }
            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);
            wave2Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave2Clear)
            {
                foreach (Player player in bravers)
                {
                    if (player.IsDie) continue; // 사망시 경험치 획득 불가
                    player.GetExp(25);
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(1000);
                
                skullKnight = new SkullKnight();
                skullKnight2 = new SkullKnight();
                skullWarrior = new SkullWarrior();
                monsters[0] = skullGeneral;
                monsters[1] = skullKnight;
                monsters[2] = skullKnight2;
                monsters[3] = skullWarrior;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }
            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);
            wave3Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave3Clear)
            {
                foreach (Player player in bravers)
                {
                    player.GetExp(50);
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(2000);
                stage1Clear = true;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }
        }
        public void Stage2Start(Player[] bravers, Inventory inventory) 
        {
            bool wave1Clear = false;
            bool wave2Clear = false;
            bool wave3Clear = false;

            Creature creature1 = new Creature();
            Creature creature2 = new Creature();
            LowVampire lowVampire1 = new LowVampire();
            LowVampire lowVampire2 = new LowVampire();
            HighVampire highVampire1 = new HighVampire();
            HighVampire highVampire2 = new HighVampire();
            VampireLord vampireLord = new VampireLord();

            Character[] monsters = new Character[4] { creature1, creature2, lowVampire1, lowVampire2 };

            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);

            wave1Clear = Battle.BattleStart(bravers, monsters, inventory);

            if (wave1Clear)
            {
                foreach (Player player in bravers)
                {
                    player.GetExp(25); // 사망시 경험치 획득 불가
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(1000);
                
                lowVampire1 = new LowVampire();
                lowVampire2 = new LowVampire();
                monsters[0] = highVampire1;
                monsters[1] = highVampire2;
                monsters[2] = lowVampire1;
                monsters[3] = lowVampire2;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }

            wave2Clear = Battle.BattleStart(bravers, monsters, inventory);

            if (wave2Clear)
            {
                foreach (Player player in bravers)
                {
                    if (player.IsDie) continue; 
                    player.GetExp(25);
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(1000);
                highVampire1 = new HighVampire();
                highVampire2 = new HighVampire();
                lowVampire1 = new LowVampire();

                monsters[0] = vampireLord;
                monsters[1] = highVampire1;
                monsters[2] = highVampire2;
                monsters[3] = lowVampire1;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }
            wave3Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave3Clear)
            {
                foreach (Player player in bravers)
                {
                    player.GetExp(50);
                    if (!player.IsDie) player.TurnReset();
                }
                inventory.GetMoney(2000);
                stage1Clear = true;
            }
            else
            {
                Town.TownRecall(bravers);
                return;
            }
        }
        public void Stage3Start(Player[] bravers, Inventory inventory) 
        {
            bool isClear = false;

            CorruptedHero corruptedHero = new CorruptedHero();
            DeathDragon deathDragon = new DeathDragon();
            DemonKing demonKing = new DemonKing();
            DragonKing dragonKing = new DragonKing();

            Character[] monsters = new Character[4] { demonKing, dragonKing, corruptedHero, deathDragon };

            isClear = Battle.BattleStart(bravers, monsters, inventory);
            if (isClear)
            {
                Program.GameClear = true;
                UI.EndingCredit();
            }
            else
            {
                Town.TownRecall(bravers);
            }
        }

        public void StageList()
        {
            UI.Clear();
            Console.SetCursorPosition(30, 8);
            Console.Write("1. 마왕성 1F");
            Console.SetCursorPosition(30, 11);
            Console.Write("2. 마왕성 2F");
            Console.SetCursorPosition(30, 14);
            Console.Write("3. 마왕성 3F");
            Console.SetCursorPosition(30, 17);
            Console.Write("4. 뒤로");
        }

        public int StageSelectPointer(int selectCount)
        {
            ConsoleKeyInfo cki;
            int nowPointerY = 8;
            int y = 8;
            int selectNumber = 1;
            bool actionSelect = false;
            Console.SetCursorPosition(26, 8);
            Console.SetCursorPosition(26, 8);
            Console.Write("☞");

            while (!actionSelect)
            {
                cki = Console.ReadKey();


                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        y -= 3;
                        selectNumber--;
                        break;
                    case ConsoleKey.DownArrow:
                        y += 3;
                        selectNumber++;
                        break;
                    case ConsoleKey.Spacebar:
                        actionSelect = true;
                        break;
                }

                if (selectNumber > 0 && selectNumber <= selectCount)
                {
                    Console.SetCursorPosition(26, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                else if (selectNumber <= 0)
                {
                    y = 8 + (selectCount - 1) * 3;
                    selectNumber = selectCount;
                    Console.SetCursorPosition(26, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                else
                {
                    y = 8;
                    selectNumber = 1;
                    Console.SetCursorPosition(26, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(26, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
            } // loop : 행동 선택

            return selectNumber;
        }

        public void PrintCastle()
        {
            Console.SetCursorPosition(66, 8);
            Console.Write(" .#,.......#. .. .. ...# ");
            Console.SetCursorPosition(66, 9);
            Console.Write(" #~#., ., #~#.,. ,. .,#~#");
            Console.SetCursorPosition(66, 10);
            Console.Write(",#~#. ,. ,#~#- .,  ,  #~#-.");
            Console.SetCursorPosition(66, 11);
            Console.Write("#-~~#- .,#~~~#~. ,. ,#:~~#");
            Console.SetCursorPosition(66, 12);
            Console.Write("@-!:@@@@@@@@@@@@@@@@@@:!:@");
            Console.SetCursorPosition(66, 13);
            Console.Write("@-~~@- .,#~~~@~. ,. ,#:~~@");
            Console.SetCursorPosition(66, 14);
            Console.Write("@-~~@****************@:~~@");
            Console.SetCursorPosition(66, 15);
            Console.Write("@-!:#~-~~~~~~~~~~~~~~@:;:@");
            Console.SetCursorPosition(66, 16);
            Console.Write("@::;@:-!:##=~~-!~~-!:@::;@");
            Console.SetCursorPosition(66, 17);
            Console.Write("@:!;@:!*#!*#;~!!~~!!:@:;;@");
            Console.SetCursorPosition(66, 18);
            Console.Write("@:~;@:~#*~!*#:~~~~~~~@:~;@");
            Console.SetCursorPosition(66, 19);
            Console.Write("@:!;@:#=~-!~*#;~~~~~~@:!!@");
            Console.SetCursorPosition(66, 20);
            Console.Write("@:~;@:#=~-!~*#:!~~-!:@:~;@");
            Console.SetCursorPosition(66, 21);
            Console.Write("@::;@!#=~:!~*#=!~~;!~@:~;@");
            Console.SetCursorPosition(66, 22);
            Console.Write("@;;!@!#=~**~*#*:~~~~~@;:!#");
        }
    }
}
