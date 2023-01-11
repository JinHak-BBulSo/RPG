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
        static public bool BattleStart(Player[] bravers, Character[] monsters, Inventory inventory)
        {
            bool isClear = false;
            while (true)
            {
                UI.TextClear();
                int liveCharacter = 4;
                bool playerAllDie = (bravers[0].IsDie && bravers[1].IsDie && bravers[2].IsDie && bravers[3].IsDie);
                bool monsterAllDie = (monsters[0].IsDie && monsters[1].IsDie && monsters[2].IsDie && monsters[3].IsDie);
                bool playerTurnFinish = (bravers[0].TurnFinish && bravers[1].TurnFinish &&
                    bravers[2].TurnFinish && bravers[3].TurnFinish);

                foreach(var item in bravers)
                {
                    if (item.IsDie) liveCharacter--;
                }

                while (!playerTurnFinish) 
                { 
                    int selectCharacterNumber = CharacterSelect(bravers);
                    bravers[selectCharacterNumber - 1].ActionSelect(bravers, monsters, selectCharacterNumber, inventory);
                    if (bravers[selectCharacterNumber - 1].IsAvoid) return false;
                    UI.CharacterSetting(bravers);
                    UI.MonsterSetting(monsters);
                    monsterAllDie = (monsters[0].IsDie && monsters[1].IsDie && monsters[2].IsDie && monsters[3].IsDie);
                    if (monsterAllDie) break;
                    playerTurnFinish = (bravers[0].TurnFinish && bravers[1].TurnFinish &&
                    bravers[2].TurnFinish && bravers[3].TurnFinish);
                }
                if (monsterAllDie)
                {
                    Console.SetCursorPosition(35, 27);
                    Console.WriteLine("승리했습니다!");
                    isClear = true;
                    return isClear;
                }

                Task.Delay(1000).Wait();

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
                    Town.TownRecall(bravers);
                    return isClear;
                }

                foreach (var item in monsters)
                {
                    if (!item.IsDie) item.TurnReset();
                }

                foreach (var item in bravers)
                {
                    if (!item.IsDie) item.TurnReset();
                    item.AutoMPRecovery();
                }
            }
        }

        static public int CharacterSelect(Player[] bravers)
        {
            int selectCharacterNumber = 0;
            UI.ControlChaTextClear();
            UI.TextClear();

            while (selectCharacterNumber == 0)
            {
                UI.PrintCharacterList();      
                selectCharacterNumber = UI.SelectPointer(4);
                if (bravers[selectCharacterNumber - 1].TurnFinish)
                {
                    UI.TextClear();
                    Console.SetCursorPosition(35, 27);
                    Console.Write("{0}은 이미 행동을 마쳤습니다.", bravers[selectCharacterNumber - 1].JobName);
                    selectCharacterNumber = 0;
                }
                else if (bravers[selectCharacterNumber - 1].IsDie)
                {
                    UI.TextClear();
                    Console.SetCursorPosition(35, 27);
                    Console.Write("{0}은 현재 전투 불능입니다.", bravers[selectCharacterNumber - 1].JobName);
                    selectCharacterNumber = 0;
                }
            }

            return selectCharacterNumber;
        }
    }
}
