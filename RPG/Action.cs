using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Action
    {
        string[,] effect = new string[20, 20];
        string[,] effect2 = new string[20, 20];
        string[,] smalleffect = new string[9, 20];
        string[,] smalleffect2 = new string[20, 2];
        string[,] smalleffect3 = new string[2, 20];
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

            int x = 43;
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
        public void DoubleSlash()
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

            int x = 43;
            int y = 6;
            UI.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (effect2[i, j] == " ") Console.Write(effect2[i, j].PadRight(2));
                    else
                        Console.Write(effect[i, j]);
                    if (((j) % 20) == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Task.Delay(2).Wait();
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
                        Task.Delay(2).Wait();
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    if (i == 0)
                    {
                        effect2[i, i] = "■";
                        break;
                    }
                    else if (j == i || j == i + 1 || j == i + 2)
                    {
                        effect2[i, j] = "■";
                    }
                    else
                    {
                        effect2[i, j] = " ";
                    }
                }
            }

            x = 45;
            y = 6;
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (effect2[i, j] == " ") Console.Write(effect2[i, j].PadRight(2));
                    else
                        Console.Write(effect2[i, j]);
                    if (((j) % 20) == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Task.Delay(2).Wait();
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
                        Task.Delay(2).Wait();
                    }
                }
            }
        }
        public void VerticalSlash()
        {
            for(int i = 2; i < 19; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    if (j == 9 || j == 10)
                        effect[i, j] = "■";
                    else effect[i, j] = " ";
                }
            }

            int x = 45, y = 6;
            UI.Clear();
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (effect2[i, j] == " ") Console.Write(effect2[i, j].PadRight(2));
                    else
                        Console.Write(effect[i, j]);
                    if (((j) % 20) == 19)
                    {
                        Console.SetCursorPosition(x, y);
                        y++;
                        Task.Delay(5).Wait();
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
        public void Bless()
        {
            
        }
        public void Excalibur()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            UI.Clear();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    smalleffect3[i, j] = "■";
                }
            }
            int x = 43;
            int y = 16;
            Console.SetCursorPosition(x, 15);
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(smalleffect3[i, j]);
                }
                Task.Delay(10).Wait();
                x += 2;
                y = 16;
            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    smalleffect2[i, j] = "■";
                }
            }
            x = 63;
            y = 6;
        }
        public void FinalJudgment()
        {
            UI.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    smalleffect3[i, j] = "■";
                }
            }
            int x = 43;
            int y = 16;
            Console.SetCursorPosition(x, 15);
            for(int j = 0; j < 20; j++)
            {
                for(int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(smalleffect3[i, j]);
                }
                Task.Delay(10).Wait();
                x += 2;
                y = 16;
            }
            x = 43;
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(" ".PadRight(2));
                }
                Task.Delay(10).Wait();
                x += 2;
                y = 16;
            }

            x = 43;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    smalleffect[i, j] = "■";
                }
            }

            y = 0;
            for(int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(x, y);
                for(int j = 0; j < 20; j++)
                {
                    Console.SetCursorPosition(x, 15 - y);
                    Console.Write(smalleffect[i, j]);
                    Console.SetCursorPosition(x, 15 + y);
                    Console.Write(smalleffect[i, j]);
                    x += 2;
                }
                Task.Delay(10).Wait();
                x = 43;
                y++;
            }

            y = 0;
            for (int i = 0; i < 9; i++)
            {
                Console.SetCursorPosition(x, y);
                for (int j = 0; j < 20; j++)
                {
                    Console.SetCursorPosition(x, 15 - y);
                    Console.Write(" ".PadRight(2));
                    Console.SetCursorPosition(x, 15 + y);
                    Console.Write(" ".PadRight(2));
                    x += 2;
                }
                Task.Delay(10).Wait();
                x = 43;
                y++;
            }
        }
    }
}