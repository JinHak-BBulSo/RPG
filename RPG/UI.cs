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
            Console.WriteLine("마왕성 공략하기");
            for(int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(118, i + 1);
                Console.WriteLine("■");
            }

            Console.SetCursorPosition(0, 4);
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            
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
            Console.SetCursorPosition(0, 32);
        }
    }
}
