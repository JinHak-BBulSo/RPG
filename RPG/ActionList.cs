using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPG
{
    internal class ActionList
    {
        static public void PrintActionList()
        {
            Console.SetCursorPosition(44, 8);
            Console.Write("1. 공격");
            Console.SetCursorPosition(44, 12);
            Console.Write("2. 스킬");
            Console.SetCursorPosition(44, 16);
            Console.Write("3. 아이템");
            Console.SetCursorPosition(44, 20);
            Console.Write("4. 후퇴");
        }
        static public void PrintAttackList(string name)
        {
            UI.Clear();
            switch (name)
            {  
                case "용사":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 수직베기");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 슬래쉬");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 더블 슬래쉬");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "팔라딘":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 횡베기");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 십자 베기");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 쉴드 어택");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "현자":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 아이스클 렌스");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 파이어 볼");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 윈드 엣지");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "성녀":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 메이스 어택");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 세인트 볼");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 크로스 라이트");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
            }
        }

        static public void PrintSkillList(string name)
        {
            UI.Clear();
            switch (name)
            {
                case "용사":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 영광의 축복");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 성검 : 엑스칼리버");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 최후의 심판");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "팔라딘":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 세라픽 페더");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 디바인 생츄어리");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 저지먼트 콜");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "현자":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 블리자드");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 헬파이어");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 템페스트");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
                case "성녀":
                    Console.SetCursorPosition(44, 8);
                    Console.Write("1. 힐");
                    Console.SetCursorPosition(44, 12);
                    Console.Write("2. 미라클 샤인");
                    Console.SetCursorPosition(44, 16);
                    Console.Write("3. 리저렉션");
                    Console.SetCursorPosition(44, 20);
                    Console.Write("4. 뒤로");
                    break;
            }
        }
    }
}
