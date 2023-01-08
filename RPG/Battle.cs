using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Monster;
using RPG.PlayerCharacter;

namespace RPG
{
    internal class Battle
    {
        static public void SampleBattle(Character[] bravers, Character[] monsters)
        {
            while (true)
            {
                bool playerAllDie = (bravers[0].IsDie && bravers[1].IsDie && bravers[2].IsDie && bravers[3].IsDie);
                bool monsterAllDie = (monsters[0].IsDie && monsters[1].IsDie && monsters[2].IsDie && monsters[3].IsDie);

                foreach (var item in bravers)
                {
                    if (!item.IsDie)
                        item.ActionSelect(bravers, monsters);
                    UI.CharacterSetting(bravers);
                    UI.MonsterSetting(monsters);
                    monsterAllDie = (monsters[0].IsDie && monsters[1].IsDie && monsters[2].IsDie && monsters[3].IsDie);
                    if (monsterAllDie) break;
                }
                if (monsterAllDie)
                {
                    Console.SetCursorPosition(35, 27);
                    Console.WriteLine("승리했습니다.!");
                    break;
                }

                foreach (var item in bravers)
                {
                    if (!item.IsDie) item.TurnReset();
                }

                foreach (var item in monsters)
                {
                    if (!item.IsDie) item.ActionSelect(bravers);
                    UI.CharacterSetting(bravers);
                    UI.MonsterSetting(monsters);
                    playerAllDie = (bravers[0].IsDie && bravers[1].IsDie && bravers[2].IsDie && bravers[3].IsDie);
                    if (playerAllDie) break;
                }

                if (playerAllDie)
                {
                    Console.SetCursorPosition(35, 27);
                    Console.WriteLine("패배했습니다.");
                    break;
                }

                foreach (var item in monsters)
                {
                    if (!item.IsDie) item.TurnReset();
                }
            }
        }
    }
}
