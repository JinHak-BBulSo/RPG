using RPG.PlayerCharacter;
using RPG.Monster;
using System;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool GameClear = false;
            UI.SetUI();
            Stage stage = new Stage();
            /*UI.StartIntro();
            Task.Delay(2000).Wait();*/
            UI.Clear();
            Braver braver = new Braver();
            Paladin paladin = new Paladin();
            Sage sage = new Sage();
            Saint saint = new Saint();
            Inventory inventory = new Inventory();

            Braver braver2 = new Braver();
            Braver braver3 = new Braver();
            Braver braver4 = new Braver();
            Player[] bravers = new Player[4] { braver, paladin, sage, saint };
            UI.CharacterSetting(bravers);

            while (!GameClear)
            {
                Town.TownStart(inventory, stage, bravers);              
            }
        }
    }
}