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
// Created On:   2018/12/31 01:10
// Modified On:  2018/12/31 01:11
// Modified By:  Alexis

#endregion




using System;

namespace SuperMemoAssistant.Plugins.Dictionary.Interop.OxfordDictionaries.Models
{
  /// <summary>A type of dictionary</summary>
  [Serializable]
  public enum DictionaryType
  {
    Monolingual,
    Bilingual
  }

  /// <summary>A class that hold information about dictionary</summary>
  [Serializable]
  public class OxfordDictionary
  {
    #region Properties & Fields - Public

    /// <summary>The region e.g. gb or us, this property maybe null</summary>
    public string Region { get; set; }

    /// <summary>The source of this dictionary</summary>
    public string Source { get; set; }

    /// <summary>The source language of this dictionary in IANA language code</summary>
    public string SourceLanguage { get; set; }

    /// <summary>
    ///   The translate to language of this dictionary in IANA language code, this property is
    ///   null if Type is Monolingual
    /// </summary>
    public string TargetLanguage { get; set; }

    // The type of this dictionary
    public DictionaryType Type { get; set; }

    #endregion
  }
}
