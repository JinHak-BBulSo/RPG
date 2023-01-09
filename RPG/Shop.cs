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
            int itemPrice = 0;
            inventory.PrintInventory();
            selectItemNumber =  UI.InventoryPointer();

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
            }
        }

        static public void PrintPurchaseCheck()
        {
            Console.SetCursorPosition(44, 8);
            Console.Write("1. 구매");
            Console.SetCursorPosition(44, 11);
            Console.Write("2. 뒤로");
        }
    }
}
