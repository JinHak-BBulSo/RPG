using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Town
    {
        static public void TownRecall(Player[] bravers)
        {
            foreach(Player player in bravers)
            {
                player.Recall();
                Console.SetCursorPosition(35, 27);
                Console.Write("전멸로 인해 마을로 복귀합니다.");
                Task.Delay(2000).Wait();
            }
        }
        static public void TownStart(Inventory inventory, Stage stage, Player[] bravers)
        {
            int selectActionNumber = 0;
            int pickNumber = 0;

            while (selectActionNumber != 2)
            {
                ActionList.TownStartActionList();
                selectActionNumber = UI.SelectPointer(3);

                switch (selectActionNumber)
                {
                    case 1:
                        Shop.PurchaseItem(inventory);
                        UI.ControlChaTextClear();
                        break;
                    case 2:  
                        while (pickNumber == 0)
                        {
                            UI.Clear();
                            stage.StageList();
                            stage.PrintCastle();
                           
                            pickNumber = stage.StageSelectPointer(5);
                            switch (pickNumber)
                            {
                                case 1:
                                    stage.Stage1Start(bravers, inventory);
                                    break;
                                case 2:
                                    if (stage.Stage1Clear)
                                    {
                                        UI.TextClear();
                                        stage.Stage2Start(bravers, inventory);
                                    }
                                    else
                                    {
                                        UI.TextClear();
                                        Console.SetCursorPosition(35, 27);
                                        Console.Write("스테이지 1을 클리어하지 않아 입장 불가능합니다.");
                                        pickNumber = 0;
                                        continue;
                                    }
                                    break;
                                case 3:
                                    if (stage.Stage2Clear)
                                    {
                                        stage.Stage3Start(bravers, inventory);
                                    }
                                    else
                                    {
                                        UI.TextClear();
                                        Console.SetCursorPosition(35, 27);
                                        Console.Write("스테이지 2를 클리어하지 않아 입장 불가능합니다.");
                                        pickNumber = 0;
                                        continue;
                                    }
                                    break;
                                case 4:
                                    if (stage.Stage3Clear)
                                    {
                                        stage.BossStageStart(bravers, inventory);
                                    }
                                    else
                                    {
                                        UI.TextClear();
                                        Console.SetCursorPosition(35, 27);
                                        Console.Write("스테이지 3을 클리어하지 않아 입장 불가능합니다.");
                                        pickNumber = 0;
                                        continue;
                                    }
                                    break;
                                default:
                                    selectActionNumber = 0;
                                    break;
                            }
                            if (pickNumber == 5)
                            {
                                pickNumber = 0;
                                break;
                            }
                        }
                        break;
                    case 3:
                        UI.ControlChaTextClear();
                        Console.SetCursorPosition(22, 5);
                        Console.Write("보유 골드 : {0}", inventory.Money);
                        inventory.PrintInventory();
                        while (pickNumber != 9)
                        {
                            pickNumber = UI.InventoryPointer(inventory);
                        }
                        UI.ControlChaTextClear();
                        pickNumber = 0;
                        break;
                }
            }
        }
    }
}
