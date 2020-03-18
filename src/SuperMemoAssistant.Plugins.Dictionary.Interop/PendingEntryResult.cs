﻿#region License & Metadata

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
// Created On:   2018/12/31 05:51
// Modified On:  2019/02/23 14:02
// Modified By:  Alexis

#endregion




using System.Threading.Tasks;
using SuperMemoAssistant.Plugins.Dictionary.Interop.OxfordDictionaries.Models;
using SuperMemoAssistant.Sys.Remoting;

namespace SuperMemoAssistant.Plugins.Dictionary.Interop
{
  public class PendingEntryResult
  {
    #region Constructors

    public PendingEntryResult(RemoteCancellationTokenSource cancellationTokenSrc,
                              Task<EntryResult>             entryResultTask,
                              IDictionaryService            plugin)
    {
      CancellationTokenSrc = cancellationTokenSrc;
      EntryResultTask      = entryResultTask;
      Plugin               = plugin;
    }

    #endregion




    #region Properties & Fields - Public

    public RemoteCancellationTokenSource CancellationTokenSrc { get; }
    public Task<EntryResult>             EntryResultTask      { get; }
    public IDictionaryService            Plugin               { get; }

    #endregion
  }
}
