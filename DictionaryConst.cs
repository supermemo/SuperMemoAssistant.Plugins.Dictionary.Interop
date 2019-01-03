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

    #endregion
  }
}
