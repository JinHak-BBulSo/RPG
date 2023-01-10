using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Shop
    {
        static public void PurchaseItem(Inventory inventory)
        {
            int selectItemNumber = 0;
            int purchaseCheck = 0;
            int itemPrice = 0;
            while (true)
            {
                UI.ControlChaTextClear();
                Console.SetCursorPosition(22, 5);    
                Console.Write("보유 골드 : {0}", inventory.Money);
                if (selectItemNumber == 0)
                {
                    inventory.PrintInventory();
                    selectItemNumber = UI.InventoryPointer(inventory);

                    switch (selectItemNumber)
                    {
                        case 1:
                        case 2:
                            itemPrice = 300;
                            break;
                        case 3:
                        case 4:
                            itemPrice = 600;
                            break;
                        case 5:
                        case 6:
                            itemPrice = 500;
                            break;
                        case 7:
                        case 8:
                            itemPrice = 1000;
                            break;
                        default:
                            break;
                    }
                    if (selectItemNumber == 9) return;
                }
                PrintPurchaseCheck();
                purchaseCheck = UI.SelectPointer(2);
                if (purchaseCheck == 1)
                {
                    if (inventory.Money > itemPrice)
                    {
                        inventory.GetItem(selectItemNumber);
                        inventory.UseMomey(itemPrice);
                        selectItemNumber = 0;
                    }
                    else
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("소지금이 부족해 구매가 불가능합니다.");
                        continue;
                    }
                }
                else
                {
                    selectItemNumber = 0;
                    continue;
                }
            }
        }

        static public void PrintPurchaseCheck()
        {
            UI.Clear();
            Console.SetCursorPosition(44, 8);
            Console.Write("1. 구매");
            Console.SetCursorPosition(44, 11);
            Console.Write("2. 뒤로"); 
        }
    }
}
