using System.Linq;
using RuOsk.Transliteration.Interfaces;

namespace TransliterationRU.Engine
{
    public class Engine
    {
        private readonly ITransliteration _transliteration;

        public Engine(ITransliteration transliteration)
        {
            _transliteration = transliteration;
        }

        public string Trasliterate(string text)
        {
            text = _transliteration.Dictionary.Keys.Aggregate(text, (current, key) => current.Replace(key, _transliteration.Dictionary[key]));

            return _transliteration.Dictionary.Keys.Aggregate(text, (current, key) => current.Replace(key.ToUpper(), _transliteration.Dictionary[key].ToUpper()));
        }


        public string TransliterateReverse(string text)
        {
            text = _transliteration.DictionaryReversed.Keys.Aggregate(text, (current, key) => current.Replace(key, _transliteration.DictionaryReversed[key]));

            return _transliteration.DictionaryReversed.Keys.Aggregate(text, (current, key) => current.Replace(key.ToUpper(), _transliteration.DictionaryReversed[key].ToUpper()));
        }
    }
}
