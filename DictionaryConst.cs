#region License & Metadata

// The MIT License (MIT)
// 
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// 
// 
// Created On:   2018/12/31 05:35
// Modified On:  2018/12/31 05:35
// Modified By:  Alexis

#endregion




namespace SuperMemoAssistant.Plugins.Dictionary.Interop {
  public static class DictionaryConst
  {
    #region Constants & Statics

    public const string Loading = @"<body>
 <div style=""margin: auto""><p>Loading...</p></div>
</body>";

    public const string Error = @"<body>
 <div style=""margin: auto""><p>An error occured while looking up the definition.</p></div>
</body>";

    public const string DefinitionSkeleton = @"<body>

 <h3>{0}</h3>
 
 {1}

</body>";
    public const string DefinitionSeparator = @"

 <div style=""margin-bottom: 10px; border-top: 1px solid #C9C9C9;""></div>

";
    public const string DefinitionEntry = @"<span><b>{0}</b></span> <span style=""margin-left: 2px; padding-left: 10px; border-left: 1px dotted #444;"">{1}</span>
 <ol>
  {2}
 </ol>";
    public const string DefinitionEntryEtymology = @"<span><b>{0}</b></span> <span style=""margin-left: 2px; padding-left: 10px; border-left: 1px dotted #444;"">{1}</span>
 <ol>
  {2}
 </ol>
 <p style=""font-size: 0.8em;""><u>Etymology</u>: {3}</p>";
    public const string DefinitionEntrySense = @"<li>
   {0}
  </li>";
    public const string DefinitionEntryExampleSense = @"<li>
   {0}
   <ul>
    {1}
   </ul>
  </li>";
    public const string DefinitionEntryExampleItem = @"<li><i>{0}</i></li>";


    public const double DefaultExtractPriority = 30.0;

    public const string OxfordLanguagesJson = @"[
  {
    ""region"": ""gb"",
    ""source"": ""Oxford Dictionary of English 3e"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""monolingual""
  },
  {
    ""region"": ""us"",
    ""source"": ""New Oxford American Dictionary 3e"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Oxford Spanish Dictionary 5e"",
    ""sourceLanguage"": {
      ""id"": ""es"",
      ""language"": ""Spanish""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Oxford Thesaurus of English"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""English Sentences Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Spanish Sentences Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""es"",
      ""language"": ""Spanish""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Oxford Spanish Dictionary 5e"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""es"",
      ""language"": ""Spanish""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Oxford Spanish Dictionary 5e"",
    ""sourceLanguage"": {
      ""id"": ""es"",
      ""language"": ""Spanish""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Oxford Bilingual School Dictionary: isiZulu and English"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""zu"",
      ""language"": ""isiZulu""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Oxford Bilingual School Dictionary: isiZulu and English"",
    ""sourceLanguage"": {
      ""id"": ""zu"",
      ""language"": ""isiZulu""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Oxford Bilingual School Dictionary: Northern Sotho and English"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""nso"",
      ""language"": ""Northern Sotho""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Oxford Bilingual School Dictionary: Northern Sotho and English"",
    ""sourceLanguage"": {
      ""id"": ""nso"",
      ""language"": ""Northern Sotho""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Romanian Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""ro"",
      ""language"": ""Romanian""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Monolingual Hindi Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""hi"",
      ""language"": ""Hindi""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Monolingual Swahili Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""sw"",
      ""language"": ""Swahili""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Monolingual Latvian Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""lv"",
      ""language"": ""Latvian""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Urdu English Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""ur"",
      ""language"": ""Urdu""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Malay Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""ms"",
      ""language"": ""Malay""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Malay Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""ms"",
      ""language"": ""Malay""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Setswana Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""tn"",
      ""language"": ""Setswana""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Setswana Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""tn"",
      ""language"": ""Setswana""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Indonesian Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""id"",
      ""language"": ""Indonesian""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Indonesian Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""id"",
      ""language"": ""Indonesian""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English German Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""de"",
      ""language"": ""German""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English German Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""de"",
      ""language"": ""German""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Portuguese Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""targetLanguage"": {
      ""id"": ""pt"",
      ""language"": ""Portuguese""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Bilingual English Portuguese Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""pt"",
      ""language"": ""Portuguese""
    },
    ""targetLanguage"": {
      ""id"": ""en"",
      ""language"": ""English""
    },
    ""type"": ""bilingual""
  },
  {
    ""source"": ""Monolingual Tamil Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""ta"",
      ""language"": ""Tamil""
    },
    ""type"": ""monolingual""
  },
  {
    ""source"": ""Monolingual Gujarati Dictionary"",
    ""sourceLanguage"": {
      ""id"": ""gu"",
      ""language"": ""Gujarati""
    },
    ""type"": ""monolingual""
  }
]";

    #endregion
  }
}
