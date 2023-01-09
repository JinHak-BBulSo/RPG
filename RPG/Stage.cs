using RPG.Monster;
using RPG.PlayerCharacter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    internal class Stage
    {
        static public void Stage1Start(Player[] bravers, Inventory inventory)
        {
            bool wave1Clear = false;
            bool wave2Clear = false;
            bool wave3Clear = false;

            SkullArchor skullArchor = new SkullArchor();
            SkullArchor skullArchor2 = new SkullArchor();
            SkullWarrior skullWarrior = new SkullWarrior();
            SkullWarrior skullWarrior2 = new SkullWarrior();
            Character[] monsters = new Character[4] { skullArchor, skullArchor2, skullWarrior, skullWarrior2 };

            UI.CharacterSetting(bravers);
            UI.MonsterSetting(monsters);

            wave1Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave1Clear)
            {
                SkullKnight skullKnight = new SkullKnight();
                SkullKnight skullKnight2 = new SkullKnight();
                skullArchor = new SkullArchor();
                skullWarrior = new SkullWarrior();
                monsters[0] = skullKnight;
                monsters[1] = skullKnight2;
                monsters[2] = skullArchor;
                monsters[3] = skullWarrior;
            }
            wave2Clear = Battle.BattleStart(bravers, monsters, inventory);
            if (wave2Clear)
            {
                SkullGeneral skullGeneral = new SkullGeneral();
                SkullKnight skullKnight = new SkullKnight();
                SkullKnight skullKnight2 = new SkullKnight();
                skullWarrior = new SkullWarrior();
                monsters[0] = skullGeneral;
                monsters[1] = skullKnight;
                monsters[2] = skullKnight2;
                monsters[3] = skullWarrior;
            }
            wave3Clear = Battle.BattleStart(bravers, monsters, inventory);

        }
        public void Stage2Set() { }
        public void Stage3Set() { }
        public void BossStageSet()
        {

        }
    }
}
