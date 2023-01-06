using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Action
    {
        string[,] effect = new string[20, 20];
        public void Slash()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i == 0)
                    {
                        effect[i, 19] = "■";
                        break;
                    }
                    else if (i == 19)
                    {
                        break;
                    }
                    else if (j == (20 - i - 1) || j == (20 - i) || j == (20 - i - 2))
                    {
                        effect[i, j] = "■";
                    }
                    else
                    {
                        effect[i, j] = " ";
                    }
                }
            }

            int x = 45;
            int y = 6;
            UI.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (effect[i, j] == " ") Console.Write(effect[i, j].PadRight(2));
                    else
                        Console.Write(effect[i, j]);
                    if (((j) % 20) == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Task.Delay(10).Wait();
                    }

                }
            }
            y = 6;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(" ".PadRight(2));
                    if (((j) % 20) == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Task.Delay(10).Wait();
                    }

                }
            }
        }
    }
}
