using System.Collections.Generic;
using RuOsk.Transliteration.Const;

namespace RuOsk.Transliteration.Interfaces
{
    public interface ITransliteration
    {
        string Name { get; }
        LanguageCodes LanguageCode { get; }
        Dictionary<string, string> Dictionary { get; }
        Dictionary<string, string> DictionaryReversed { get; }
    }
}
