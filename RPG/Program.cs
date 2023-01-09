using RPG.PlayerCharacter;
using RPG.Monster;
using System;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            UI.SetUI();
            UI.StartIntro();
            Task.Delay(3000).Wait();
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

            Stage.Stage1Start(bravers, inventory);
        }
    }
}