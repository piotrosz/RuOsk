using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RuOsk.Transliteration.Interfaces;

namespace TransliterationRU.Engine
{
    public class Engine
    {
        private ITransliteration _Transliteration;

        public Engine(ITransliteration transliteration)
        {
            this._Transliteration = transliteration;
        }

        public string Trasliterate(string text)
        {
            foreach (string key in _Transliteration.Dictionary.Keys)
                text = text.Replace(key, _Transliteration.Dictionary[key]);

            foreach (string key in _Transliteration.Dictionary.Keys)
                text = text.Replace(key.ToUpper(), _Transliteration.Dictionary[key].ToUpper());
            
            return text;
        }


        public string TransliterateReverse(string text)
        {
            foreach (string key in _Transliteration.DictionaryReversed.Keys)
                text = text.Replace(key, _Transliteration.DictionaryReversed[key]);

            foreach (string key in _Transliteration.DictionaryReversed.Keys)
                text = text.Replace(key.ToUpper(), _Transliteration.DictionaryReversed[key].ToUpper());


            return text;
        }
    }
}
