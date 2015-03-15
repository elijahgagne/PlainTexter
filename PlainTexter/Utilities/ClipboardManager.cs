using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlainTexter.Utilities
{
    public class ClipboardManager
    {
        public static void UpdateClipboardToPlainText()
        {
            Clipboard.SetDataObject(Clipboard.GetText(), true);
        }

        public static string GetClipboardDataFormat()
        {
            string subtype = "";
            
            if (Clipboard.ContainsAudio())
            {
                return "Audio";
            }
            else if (Clipboard.ContainsFileDropList())
            {
                return "File";
            }
            else if (Clipboard.ContainsText())
            {
                if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
                {
                    subtype = "CommaSeparatedValue";
                }
                else if (Clipboard.ContainsText(TextDataFormat.Html))
                {
                    subtype = "Html";
                }
                else if (Clipboard.ContainsText(TextDataFormat.Rtf))
                {
                    subtype = "Rtf";
                }
                else if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                {
                    subtype = "UnicodeText";
                }
                else if (Clipboard.ContainsText(TextDataFormat.Xaml))
                {
                    subtype = "Xaml";
                }
                else if (Clipboard.ContainsText(TextDataFormat.Text))
                {
                    subtype = "Text";
                }
                else
                {
                    subtype = "Unknown type";
                }

                return "Text: " + subtype;
            }
            else if (Clipboard.ContainsImage())
            {
                return "Image";
            }
            else
            {
                return "Clipboard is empty.";
            }
        }


        public static string GetClipboardTextData()
        {
            if (Clipboard.ContainsText())
            {

                return Clipboard.GetText();
            }
            else
            {
                return "";
            }
        }

        public static string GetClipboardHtml()
        {
            if (Clipboard.ContainsText(TextDataFormat.Html))
            {
                string text = Clipboard.GetText(TextDataFormat.Html);
                int start = text.IndexOf("<!--StartFragment-->") + 20;
                int length = text.IndexOf("<!--EndFragment-->") - start;

                return text.Substring(start, length);
            }
            else
            {
                return "";
            }
        }

        public static string GetClipboardRtf()
        {
            if (Clipboard.ContainsText(TextDataFormat.Rtf))
            {
                return (string)Clipboard.GetDataObject().GetData(DataFormats.Rtf);
            }
            else
            {
                return "";
            }
        }

        public static string GetClipboardCommaSeparatedValue()
        {
            if (Clipboard.ContainsText(TextDataFormat.CommaSeparatedValue))
            {
                return (string)Clipboard.GetDataObject().GetData(DataFormats.CommaSeparatedValue);
            }
            else
            {
                return "";
            }
        }



    }
}
