using Client.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class Translater
    {
        public string TranslateResult { get; private set; }

        /// <summary>
        /// Translates a message from one language to another
        /// </summary>
        /// <param name="message">Message you want to translate</param>
        /// <param name="langOfMessage">Language to be translated</param>
        /// <param name="langOfResultMessage">The language of the message you want to receive</param>
        /// <returns>Translated message</returns>
        public void Translate(string message, Language langOfMessage, Language langOfResultMessage)
        {
            TranslateResult = message.ToLower();
            Dictionary<string, string> DictToTranslate = GetDictionary(langOfMessage, langOfResultMessage);

            foreach (char c in TranslateResult)
            {
                string oldString = c.ToString();
                if (DictToTranslate.ContainsKey(oldString))
                    TranslateResult = TranslateResult.Replace(oldString, DictToTranslate[oldString]);
            }
        }

        /// <summary>
        /// Gets a dictionary for translating one language to another
        /// </summary>
        /// <param name="languageNeedToTranslate">Language to be translated</param>
        /// <param name="languageResult">Language you want to get</param>
        /// <returns>Dictionary for translation from one language to another</returns>
        private Dictionary<string, string> GetDictionary(Language languageNeedToTranslate, Language languageResult)
        {
            Dictionary<string, string> rusToEngDict = new Dictionary<string, string>
            {
                { "а", "u" },
                { "б", "b" },
                { "в", "v" },
                { "г", "g" },
                { "д", "d" },
                { "е", "e" },
                { "ё", "yo" },
                { "ж", "zh" },
                { "з", "z" },
                { "и", "i" },
                { "к", "k" },
                { "л", "l" },
                { "м", "m" },
                { "н", "n" },
                { "о", "o" },
                { "п", "p" },
                { "р", "r" },
                { "с", "s" },
                { "т", "t" },
                { "у", "y" },
                { "ф", "f" },
                { "х", "h" },
                { "ц", "c" },
                { "ч", "ch" },
                { "ш", "sh" },
                { "щ", "shch" },
                { "ы", "i" },
                { "э", "e" },
                { "ю", "iy" },
                { "я", "ia" },
            };
            Dictionary<string, string> engToRusDict = new Dictionary<string, string>
            {
                { "a", "а" },
                { "b", "б" },
                { "c", "ц" },
                { "d", "д" },
                { "e", "е" },
                { "f", "ф" },
                { "g", "г" },
                { "h", "х" },
                { "i", "ш" },
                { "j", "й" },
                { "k", "к" },
                { "l", "л" },
                { "m", "м" },
                { "n", "н" },
                { "o", "о" },
                { "p", "п" },
                { "q", "кью" },
                { "r", "р" },
                { "s", "с" },
                { "t", "т" },
                { "u", "а" },
                { "v", "в" },
                { "w", "ш" },
                { "x", "икс" },
                { "y", "у" },
                { "z", "з" },
            };

            switch (languageNeedToTranslate, languageResult)
            {
                case (Language.English, Language.Russian):
                    return engToRusDict;
                case (Language.Russian, Language.English):
                    return rusToEngDict;
            }
            throw new Exception("No such dictionary is provided!");
        }
    }
}
