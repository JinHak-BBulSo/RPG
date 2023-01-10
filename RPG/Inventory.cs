using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Inventory
    {
        private string[] itemTooltip;
        public string[] ItemTooltip
        {
            get { return itemTooltip; }
            private set { itemTooltip = value; }
        }
        private Dictionary<int, (string, int)> itemInventory = new Dictionary<int, (string, int)>();
        public Dictionary<int, (string, int)> ItemInventory
        {
            get { return itemInventory; }
            private set { itemInventory = value; }
        }

        private int money = 2000;
        public int Money
        {
            get { return money; }
            private set { money = value; }
        }

        public Inventory()
        {
            itemInventory.Add(1, ("하급체력포션", 5));
            itemInventory.Add(2, ("하급마나포션", 5));
            itemInventory.Add(3, ("고급체력포션", 0));
            itemInventory.Add(4, ("고급마나포션", 0));
            itemInventory.Add(5, ("대미지증가포션", 0));
            itemInventory.Add(6, ("회복량증가포션", 0));
            itemInventory.Add(7, ("투신의함성포션", 0));
            itemInventory.Add(8, ("신의가호", 0));

            itemTooltip = new string[8] {
            "사용 시 HP가 100 회복된다. 상점가 300G",
            "사용 시 MP가 50 회복된다. 상점가 300G",
            "사용 시 HP가 230 회복된다. 상점가 600G",
            "사용 시 MP가 120 회복된다. 상점가 600G",
            "사용 시 공격력이 15 증가한다. 상점가 500G",
            "사용 시 회복력이 15 증가한다. 상점가 500G",
            "사용 시 공격력이 30 증가한다. 상점가 1000G",
            "사용 시 회복력이 20 증가한다. 상점가 1000G"
            };
        }

        public void PrintInventory()
        {
            UI.Clear();
            UI.TextClear();
            Console.SetCursorPosition(35, 27);
            Console.Write(ItemTooltip[0]);
            for (int i = 1; i <= itemInventory.Count + 1; i++)
            {
                if (i <= itemInventory.Count)
                {
                    Console.SetCursorPosition(44, i * 2 + 6);
                    Console.Write("{0} : {1}EA", itemInventory[i].Item1, itemInventory[i].Item2);
                }
                else
                {
                    Console.SetCursorPosition(44, i * 2 + 6);
                    Console.Write("뒤로가기");
                }
            }
        }

        public void UseItem(Player[] bravers, int number)
        {
            int useCharacterNumber = 0;
            if(itemInventory[number].Item2 != 0)
            {
                useCharacterNumber = ItemUseCharacterSelect(bravers);
                if (useCharacterNumber == 0) return;
                else
                {
                    if( (number == 5 || number == 7) && bravers[useCharacterNumber - 1].DamagePotionUsed)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("이미 대미지 증가 포션을 사용중입니다.");
                        Task.Delay(2000).Wait();
                        return;
                    }
                    else if((number == 6 || number == 8) && bravers[useCharacterNumber - 1].HealUpPotionUsed)
                    {
                        UI.TextClear();
                        Console.SetCursorPosition(35, 27);
                        Console.Write("이미 회복력 증가 포션을 사용중입니다.");
                        Task.Delay(2000).Wait();
                        return;
                    }
                    itemInventory[number] = (itemInventory[number].Item1, itemInventory[number].Item2 - 1);
                }
            }
            else
            {
                Console.SetCursorPosition(35, 27);
                Console.Write("아이템 재고가 0개이므로 사용할 수 없습니다.");
                return;
            }

            switch (number)
            {
                case 1:
                    bravers[useCharacterNumber - 1].Heal(100);
                    break;
                case 2:
                    bravers[useCharacterNumber - 1].MPPotion(0);
                    break;
                case 3:
                    bravers[useCharacterNumber - 1].Heal(230);
                    break;
                case 4:
                    bravers[useCharacterNumber - 1].MPPotion(1);
                    break;
                case 5:
                    bravers[useCharacterNumber - 1].DamageUpPotion(0);
                    break;
                case 6:
                    bravers[useCharacterNumber - 1].HealUpPotion(0);
                    break;
                case 7:
                    bravers[useCharacterNumber - 1].DamageUpPotion(1);
                    break;
                case 8:
                    bravers[useCharacterNumber - 1].HealUpPotion(1);
                    break;
            }
        }

        public int ItemUseCharacterSelect(Player[] bravers)
        {
            int selectCharacterNumber = 0;

            while (selectCharacterNumber == 0)
            {
                UI.PrintCharacterList();
                Console.SetCursorPosition(44, 20);
                Console.Write("5. 뒤로");
                selectCharacterNumber = UI.SelectPointer(5);
                if(selectCharacterNumber == 5)
                {
                    return 0;
                }
                else if (bravers[selectCharacterNumber - 1].IsDie)
                {
                    UI.TextClear();
                    Console.SetCursorPosition(35, 27);
                    Console.Write("{0}은 현재 전투 불능입니다.", bravers[selectCharacterNumber - 1].JobName);
                    selectCharacterNumber = 0;
                    continue;
                }
            }

            return selectCharacterNumber;
        }

        public void UseMomey(int money)
        {
            if(money > this.money)
            {
                /* Do nothing */
            }
            else
                this.money -= money;
        }

        public void GetMoney(int money)
        {
            this.money += money;
        }
        public void GetItem(int selectNumber)
        {
            itemInventory[selectNumber] = (itemInventory[selectNumber].Item1, itemInventory[selectNumber].Item2 + 1);
        }
    }
}
