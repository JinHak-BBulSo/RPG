using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class UI
    {
        static public void SetUI()
        {
            //타이틀 제목 그리기
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

            Console.WriteLine("■");
            Console.WriteLine("■");
            Console.WriteLine("■");

            Console.SetCursorPosition(118, 1);
            Console.WriteLine("■");
            Console.SetCursorPosition(118, 2);
            Console.WriteLine("■");
            Console.SetCursorPosition(118, 3);
            Console.WriteLine("■");

            Console.SetCursorPosition(50, 2);
            Console.Write("마왕성과 용사");
            for(int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(118, i + 1);
                Console.WriteLine("■");
            }

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            
            // UI용 벽그리기
            for (int i = 4; i < 28; i++)
            {
                Console.SetCursorPosition(0, i + 1);
                Console.WriteLine("■");
                Console.SetCursorPosition(118, i + 1);
                Console.WriteLine("■");
            }
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

            for (int i = 5; i < 29; i++)
            {
                Console.SetCursorPosition(20, i);
                Console.WriteLine("■");
                Console.SetCursorPosition(98, i);
                Console.WriteLine("■");
                if(i == 25)
                {
                    Console.SetCursorPosition(20, i);
                    Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
                }
            }
            
            // 플레이어 캐릭터창 나누기
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("■■■■■■■■■■■");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine("■■■■■■■■■■■");
            Console.SetCursorPosition(0, 22);
            Console.WriteLine("■■■■■■■■■■■");

            // 몬스터 캐릭터창 나누기
            Console.SetCursorPosition(98, 10);
            Console.WriteLine("■■■■■■■■■■■");
            Console.SetCursorPosition(98, 16);
            Console.WriteLine("■■■■■■■■■■■");
            Console.SetCursorPosition(98, 22);
            Console.WriteLine("■■■■■■■■■■■");

            // 커서 초기 세팅
            Console.SetCursorPosition(40, 8);
            Console.Write("☞");
            Console.SetCursorPosition(0, 0);
        }

        static public void StartIntro()
        {
            Console.SetCursorPosition(24, 8);
            string str = "용사 파티는 모험 속에서 시련을 넘어 마왕성에 도착했습니다.";
            char[] chars = new char[50];
            chars = str.ToCharArray();
            foreach(char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 10);
            str = "마왕성은 총 3개의 층으로 이루어져 있으며, 3층 심층부에 옥좌가 있습니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 12);
            str = "부디 인류를 위해 용사파티를 승리로 이끌어주시기 바랍니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 14);
            str = "용사파티는 용사와 팔라딘의 전열과 현자와 성녀의 후열로 구성되어있습니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 16);
            str = "이들의 스킬과 조합을 잘 활용해 마왕성을 공략해 나가주세요.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
        }
        static public void EndingCredit()
        {
            Console.SetCursorPosition(24, 8);
            string str = "용사가 마왕을 쓰러트렸습니다.";
            char[] chars = new char[50];
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 10);
            str = "이제 세계는 평화를 되찾았습니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 12);
            str = "용사와 동료들은 오랜시간 축복받게 되었습니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 14);
            str = "그들의 이야기는 끝니 났습니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Console.SetCursorPosition(24, 16);
            str = "플레이 해주셔서 감사합니다.";
            chars = str.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c);
                Task.Delay(30).Wait();
            }
            Task.Delay(2000).Wait();
        }

        static public int SelectPointer(int selectCount)
        {
            ConsoleKeyInfo cki;   
            int nowPointerY = 8;
            int y = 8;
            int selectNumber = 1;
            bool actionSelect = false;
            Console.SetCursorPosition(40, 8);
            Console.SetCursorPosition(40, 8);
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
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                else if (selectNumber <= 0)
                {
                    y = 8 + (selectCount - 1) * 3;
                    selectNumber = selectCount;
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                else
                {
                    y = 8;
                    selectNumber = 1;
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
            } // loop : 행동 선택

            return selectNumber;
        }
        static public int InventoryPointer(Inventory inventory)
        {
            ConsoleKeyInfo cki;
            int nowPointerY = 8;
            int y = 8;
            int selectNumber = 1;
            bool actionSelect = false;
            Console.SetCursorPosition(40, 8);
            Console.SetCursorPosition(40, 8);
            Console.Write("☞");

            while (!actionSelect)
            {
                cki = Console.ReadKey();


                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        y -= 2;
                        selectNumber--;
                        break;
                    case ConsoleKey.DownArrow:
                        y += 2;
                        selectNumber++;
                        break;
                    case ConsoleKey.Spacebar:
                        actionSelect = true;
                        break;
                }

                if (selectNumber > 0 && selectNumber <= 9)
                {
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    
                    
                    nowPointerY = y;
                }
                else if (selectNumber <= 0)
                {
                    y = 24;
                    selectNumber = 9;
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                else
                {
                    y = 8;
                    selectNumber = 1;
                    Console.SetCursorPosition(40, nowPointerY);
                    Console.Write("  ");
                    Console.SetCursorPosition(40, y);
                    Console.Write("☞");
                    nowPointerY = y;
                }
                if (selectNumber <= 8)
                {
                    TextClear();
                    Console.SetCursorPosition(35, 27);
                    Console.Write(inventory.ItemTooltip[selectNumber - 1]);
                }
                else
                {
                    TextClear();
                }
            } // loop : 행동 선택

            return selectNumber;
        }
        static public void TextClear()
        {
            Console.SetCursorPosition(22, 27);
            Console.Write("                                                                           ");
        }

        static public void Clear()
        {
            Console.SetCursorPosition(24, 8);

            for (int i = 6; i <= 24; i++)
            {
                Console.SetCursorPosition(22, i);
                Console.Write("                                                                           ");
            }
        }

        static public void CharacterSetting(Player[] characters)
        {
            //용사
            Console.SetCursorPosition(6, 6);
            Console.Write("용사(전열)");
            Console.SetCursorPosition(2, 8);
            Console.Write(" HP {0}  MP {1}  ", characters[0].Hp, characters[0].Mp);

            //팔라딘
            Console.SetCursorPosition(5, 12);
            Console.Write("팔라딘(전열)");
            Console.SetCursorPosition(2, 14);
            Console.Write(" HP {0}  MP {1}  ", characters[1].Hp, characters[1].Mp);

            //현자
            Console.SetCursorPosition(6, 18);
            Console.Write("현자(후열)");
            Console.SetCursorPosition(2, 20);
            Console.Write(" HP {0}  MP {1}  ", characters[2].Hp, characters[2].Mp);

            //성녀
            Console.SetCursorPosition(6, 24);
            Console.Write("성녀(후열)");
            Console.SetCursorPosition(2, 26);
            Console.Write(" HP {0}  MP {1}  ", characters[3].Hp, characters[3].Mp);
        }

        static public void MonsterSetting(Character[] monsters)
        {
            //용사
            Console.SetCursorPosition(102, 6);
            Console.Write("{0}", monsters[0].JobName);
            Console.SetCursorPosition(102, 8);
            Console.Write("HP {0}  MP {1}  ", monsters[0].Hp, monsters[0].Mp);

            //팔라딘
            Console.SetCursorPosition(102, 12);
            Console.Write("{0}", monsters[1].JobName);
            Console.SetCursorPosition(102, 14);
            Console.Write("HP {0}  MP {1}  ", monsters[1].Hp, monsters[1].Mp);

            //현자
            Console.SetCursorPosition(102, 18);
            Console.Write("{0}", monsters[2].JobName);
            Console.SetCursorPosition(102, 20);
            Console.Write("HP {0}  MP {1}  ", monsters[2].Hp, monsters[2].Mp);

            //성녀
            Console.SetCursorPosition(102, 24);
            Console.Write("{0}", monsters[3].JobName);
            Console.SetCursorPosition(102, 26);
            Console.Write("HP {0}  MP {1}  ", monsters[3].Hp, monsters[3].Mp);
        }
        static public void PrintCharacterList()
        {
            Clear();
            Console.SetCursorPosition(44, 8);
            Console.Write("1. 용사");
            Console.SetCursorPosition(44, 11);
            Console.Write("2. 팔라딘");
            Console.SetCursorPosition(44, 14);
            Console.Write("3. 현자");
            Console.SetCursorPosition(44, 17);
            Console.Write("4. 성녀");
        }
        
        static public void PrintMonsterList(Character[] monsters)
        {
            Clear();
            Console.SetCursorPosition(44, 8);
            Console.Write("1. {0}", monsters[0].JobName);
            Console.SetCursorPosition(44, 11);
            Console.Write("2. {0}", monsters[1].JobName);
            Console.SetCursorPosition(44, 14);
            Console.Write("3. {0}", monsters[2].JobName);
            Console.SetCursorPosition(44, 17);
            Console.Write("4. {0}", monsters[3].JobName);
            Console.SetCursorPosition(44, 20);
            Console.Write("5. 뒤로");
        }
        static public void ControlChaTextClear()
        {
            Console.SetCursorPosition(22, 5);
            Console.Write("                                                    ");
        }
        static public void HitUI(Character character, int target)
        {
            int x;
            string position = "";
            if (!character.IsMonster) x = 6;
            else x = 105;

            if (character.JobName == "팔라딘" || character.JobName == "용사")
            {
                position = "(전열)";
                if(character.JobName == "팔라딘")
                    Console.SetCursorPosition(x - 1, target * 6);
                else
                    Console.SetCursorPosition(x, target * 6);
            }
            else if(character.JobName == "현자" || character.JobName == "성녀")
            {
                position = "(후열)";
                Console.SetCursorPosition(x, target * 6);
            }
            else
            {
                Console.SetCursorPosition(x - 3, target * 6);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}{1}", character.JobName, position);
            Console.SetCursorPosition(x - 4, target * 6 + 2);
            Console.Write(" HP {0}  MP {1}  ", character.Hp, character.Mp);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}