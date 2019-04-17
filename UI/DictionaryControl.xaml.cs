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
// Created On:   2018/12/31 04:46
// Modified On:  2019/02/23 14:55
// Modified By:  Alexis

#endregion




using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using SuperMemoAssistant.Interop.SuperMemo.Elements.Builders;
using SuperMemoAssistant.Interop.SuperMemo.Elements.Models;
using SuperMemoAssistant.Plugins.Dictionary.Interop.OxfordDictionaries.Models;
using SuperMemoAssistant.Services;
using SuperMemoAssistant.Sys.Remoting;

namespace SuperMemoAssistant.Plugins.Dictionary.Interop.UI
{
  /// <summary>Interaction logic for DictionaryControl.xaml</summary>
  public partial class DictionaryControl : UserControl
  {
    #region Constants & Statics

    public static readonly DependencyProperty EntriesProperty =
      DependencyProperty.Register("Entries",
                                  typeof(PendingEntryResult),
                                  typeof(DictionaryControl),
                                  new PropertyMetadata(
                                    (o,
                                     ev) =>
                                    {
                                      var ctrl = o as DictionaryControl;
                                      if (ctrl != null && ev.NewValue != null)
                                        ctrl.OnNewEntries((PendingEntryResult)ev.NewValue);
                                    }
                                  ));

    public static readonly DependencyProperty OnBeforeExtractProperty =
      DependencyProperty.Register("OnBeforeExtract", typeof(Func<bool>), typeof(DictionaryControl));

    public static readonly DependencyProperty OnAfterExtractProperty =
      DependencyProperty.Register("OnAfterExtract", typeof(Func<bool, bool>), typeof(DictionaryControl));

    #endregion




    #region Properties & Fields - Non-Public

    private IDictionaryService Plugin { get; set; }

    private RemoteCancellationTokenSource CancelTokenSource { get; set; }

    private string Html { get; set; }

    private string Word { get; set; }

    #endregion




    #region Constructors

    //private mshtml.IHTMLDocument3 Document => (mshtml.IHTMLDocument3)Browser.Document;

    public DictionaryControl()
    {
      InitializeComponent();
    }

    #endregion




    #region Properties & Fields - Public

    public Func<bool> OnBeforeExtract
    {
      get => (Func<bool>)GetValue(OnBeforeExtractProperty);
      set => SetValue(OnBeforeExtractProperty, value);
    }


    public Func<bool, bool> OnAfterExtract
    {
      get => (Func<bool, bool>)GetValue(OnAfterExtractProperty);
      set => SetValue(OnAfterExtractProperty, value);
    }

    public PendingEntryResult Entries
    {
      set => SetValue(EntriesProperty,
                      value);
    }

    #endregion




    #region Methods Impl

    protected override void OnToolTipClosing(ToolTipEventArgs e)
    {
      CancelTokenSource.Cancel();
      CancelTokenSource = null;
      Plugin            = null;
      Html              = null;
      Word              = null;

      //LoadingIndicator.IsActive   = false;
      //LoadingIndicator.Visibility = Visibility.Collapsed;

      base.OnToolTipClosing(e);
    }

    #endregion




    #region Methods

    public bool Extract()
    {
      if (OnBeforeExtract != null && OnBeforeExtract() == false)
        return false;

      bool success = Svc.SMA.Registry.Element.Add(
        out _,
        ElemCreationFlags.CreateSubfolders,
        new ElementBuilder(ElementType.Topic,
                           Html)
          .WithParent(Plugin.RootElement)
          .WithLayout(Plugin.Layout)
          .WithPriority(Plugin.ExtractPriority)
          .WithTitle(Word)
          .DoNotDisplay()
      );

      var displayError = OnAfterExtract == null || OnAfterExtract(success);

      if (success == false && displayError)
        MessageBox.Show("Element creation failed.",
                        "Error");

      return success;
    }

    private void BtnExtract_Click(object          sender,
                                  RoutedEventArgs e)
    {
      Extract();
    }

    private void OnNewEntries(PendingEntryResult pending)
    {
      //LoadingIndicator.IsActive   = true;
      //LoadingIndicator.Visibility = Visibility.Visible;

      Browser.NavigateToString(DictionaryConst.Loading);

      CancelTokenSource = pending.CancellationTokenSrc;
      Plugin            = pending.Plugin;

      pending.EntryResultTask.ContinueWith(
        task =>
        {
          Html = task?.Result == null
            ? DictionaryConst.Error
            : BuildHtml(task.Result);

          Dispatcher.Invoke(
            () =>
            {
              //LoadingIndicator.IsActive   = false;
              //LoadingIndicator.Visibility = Visibility.Collapsed;
              Browser.NavigateToString(Html);
            }
          );
        }
      );
    }

    private string BuildHtml(EntryResult entries)
    {
      if (entries == null || entries.Results.Any() == false)
        return string.Empty;

      Word = entries.Results[0].Word;
      List<string> entriesStr = new List<string>();

      foreach (var lexEntry in entries.Results[0].LexicalEntries)
      {
        var lexCategory   = lexEntry.LexicalCategory ?? "N/A";
        var pronunciation = BuildPronunciation(lexEntry.Pronunciations);

        foreach (var gramEntry in lexEntry.Entries)
        {
          List<string> sensesStr = new List<string>();
          var          etymology = gramEntry.Etymologies?.FirstOrDefault();

          foreach (var sense in gramEntry.Senses)
          {
            if (sense.Definitions == null)
              continue;

            var definition = HtmlEncode(sense.Definitions.FirstOrDefault());

            if (sense.Examples != null)
            {
              var examplesStr = sense.Examples.Select(
                e =>
                  string.Format(DictionaryConst.DefinitionEntryExampleItem,
                                HtmlEncode(e.Text))
              );
              sensesStr.Add(
                string.Format(
                  DictionaryConst.DefinitionEntryExampleSense,
                  definition,
                  string.Join("\r\n",
                              examplesStr)
                )
              );
            }

            else
            {
              sensesStr.Add(string.Format(DictionaryConst.DefinitionEntrySense,
                                          definition));
            }
          }

          string entryStr;

          if (etymology != null)
            entryStr = string.Format(DictionaryConst.DefinitionEntryEtymology,
                                     lexCategory,
                                     pronunciation,
                                     string.Join("\r\n",
                                                 sensesStr),
                                     HtmlEncode(etymology)
            );

          else
            entryStr = string.Format(DictionaryConst.DefinitionEntry,
                                     lexCategory,
                                     pronunciation,
                                     string.Join("\r\n",
                                                 sensesStr)
            );

          entriesStr.Add(entryStr);
        }
      }

      return string.Format(DictionaryConst.DefinitionSkeleton,
                           Word,
                           string.Join(DictionaryConst.DefinitionSeparator,
                                       entriesStr)
      );
    }

    private static string BuildPronunciation(Pronunciation[] pronunciations)
    {
      if (pronunciations == null)
        return string.Empty;

      return HtmlEncode(string.Join(", ",
                                    pronunciations.Select(p => $"/{p.PhoneticSpelling}/")));
    }

    private static string HtmlEncode(string text)
    {
      // call the normal HtmlEncode first
      char[]        chars       = WebUtility.HtmlEncode(text).ToCharArray();
      StringBuilder encodedText = new StringBuilder();

      foreach (char c in chars)
        if (c > 127) // above normal ASCII
          encodedText.Append("&#" + (int)c + ";");
        else
          encodedText.Append(c);

      return encodedText.Replace("&#65534;",
                                 "-\r\n")
                        .Replace("\n",
                                 "\n<br/>")
                        .ToString();
    }

    #endregion
  }
}
