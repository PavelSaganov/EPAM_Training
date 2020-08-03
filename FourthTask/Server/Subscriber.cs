using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class Subscriber : IObserver
    {
        Func<string, string> translate = Tr2;

        public void Update()
        {
            throw new NotImplementedException();
        }

        static string Tr2(string s)
        {
            StringBuilder ret = new StringBuilder();
            string[] rus = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й",
                "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц",
                "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] eng = { "A", "B", "V", "G", "D", "E", "E", "ZH", "Z", "I", "Y",
                  "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "KH", "TS",
                  "CH", "SH", "SCH", null, "I", null, "E", "YU", "YA" };

            for (int j = 0; j < s.Length; j++)
                for (int i = 0; i < rus.Length; i++)
                    if (s.Substring(j, 1) == rus[i]) ret.Append(eng[i]);
            return ret.ToString();
        }


    }
}
