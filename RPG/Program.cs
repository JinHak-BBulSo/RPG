using RPG.PlayerCharacter;
using System;

namespace RPG
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            UI.SetUI();
            Braver braver = new Braver();
            Paladin paladin = new Paladin();
            Sage sage = new Sage();
            Saint saint = new Saint();
            Character[] bravers = new Character[4] { braver, paladin, sage, saint };
            Character[] monsters = new Character[4];
            UI.CharacterSetting(bravers);
            braver.ActionSelect(monsters);
            paladin.ActionSelect(monsters);
            sage.ActionSelect(monsters);
            saint.ActionSelect(monsters);
        }
    }
}