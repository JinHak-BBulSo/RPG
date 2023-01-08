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
            Braver braver = new Braver();
            Paladin paladin = new Paladin();
            Sage sage = new Sage();
            Saint saint = new Saint();

            Braver braver2 = new Braver();
            Braver braver3 = new Braver();
            Braver braver4 = new Braver();
            Character[] bravers = new Character[4] { braver, braver2, braver3, braver4 };

            SkullArchor skull = new SkullArchor();
            SkullArchor skull2 = new SkullArchor();
            SkullArchor skull3 = new SkullArchor();
            SkullArchor skull4 = new SkullArchor();
            Character[] monsters = new Character[4] { skull, skull2, skull3, skull4 };

            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);

            Battle.SampleBattle(bravers, monsters);
        }
    }
}