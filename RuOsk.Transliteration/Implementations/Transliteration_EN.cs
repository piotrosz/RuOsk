using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuOsk.Transliteration.Interfaces;

namespace RuOsk.Transliteration.Implementations
{
    public class Transliteration_En : ITransliteration
    {
        private static Dictionary<string, string> _Dictionary;
        private static Dictionary<string, string> _DictionaryReversed;

        public Transliteration_En()
        {
            _Dictionary = new Dictionary<string, string>() 
            { 
                { "а", "a" },
                { "б", "b" },
                { "в", "w" },
                { "г", "g" },
                { "д", "d" },
                { "е", "e" },
                { "ё", "yo" },
                { "ж", "zh" },
                { "з", "z" },
                { "и", "i" },
                { "й", "y" },
                { "к", "k" },
                { "л", "l" },
                { "м", "m" },
                { "н", "n" },
                { "о", "o" },
                { "п", "p" },
                { "р", "r" },
                { "с", "s" },
                { "т", "t" },
                { "у", "u" },
                { "ф", "f" },
                { "х", "kh" },
                { "ц", "ts" },
                { "ч", "ch" },
                { "ш", "sh" },
                { "щ", "shch" },
                { "ъ", "\"" },
                { "ы", "y" },
                { "ь", "'" },
                { "э", "e" },
                { "ю", "yu" },
                { "я", "ya" },
            };

            _DictionaryReversed = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> kvp in _Dictionary)
            {
                if(kvp.Value != "y" && kvp.Value != "e")
                    _DictionaryReversed.Add(kvp.Value, kvp.Key);
            }

            _DictionaryReversed.Add("y", "[ы/й]");
            _DictionaryReversed.Add("e", "[е/э]");
        }

        public string Name
        {
            get { return "ISO 9:1995"; }
        }

        public Const.LanguageCodes LanguageCode
        {
            get { return Const.LanguageCodes.EN;  }
        }

        public Dictionary<string, string> Dictionary
        {
            get { return _Dictionary; }
        }

        public Dictionary<string, string> DictionaryReversed
        {
            get { throw new NotImplementedException(); }
        }
    }
}
