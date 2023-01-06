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

            Console.SetCursorPosition(0, 32);
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
                        y -= 4;
                        selectNumber--;
                        break;
                    case ConsoleKey.DownArrow:
                        y += 4;
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
            } // loop : 행동 선택

            return selectNumber;
        }

        static public void Clear()
        {
            Console.SetCursorPosition(40, 8);

            for (int i = 8; i <= 28; i += 4)
            {
                Console.SetCursorPosition(40, i);
                Console.Write("                            ");
            }
        }

        static public void CharacterSetting(Character[] characters)
        {
            //용사
            Console.SetCursorPosition(6, 6);
            Console.Write("용사(전열)");
            Console.SetCursorPosition(2, 8);
            Console.Write("HP : {0}, MP : {1}", characters[0].Hp, characters[0].Mp);

            //팔라딘
            Console.SetCursorPosition(5, 12);
            Console.Write("팔라딘(전열)");
            Console.SetCursorPosition(2, 14);
            Console.Write("HP : {0}, MP : {1}", characters[1].Hp, characters[1].Mp);

            //현자
            Console.SetCursorPosition(6, 18);
            Console.Write("현자(후열)");
            Console.SetCursorPosition(2, 20);
            Console.Write("HP : {0}, MP : {1}", characters[2].Hp, characters[2].Mp);

            //성녀
            Console.SetCursorPosition(6, 24);
            Console.Write("성녀(후열)");
            Console.SetCursorPosition(2, 26);
            Console.Write("HP : {0}, MP : {1}", characters[3].Hp, characters[3].Mp);
        }
        
        static public void CharacterSelect()
        {

        }
    }
}
