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
        public static void UpdateClipboard()
        {
            Clipboard.SetDataObject(Clipboard.GetText(), true);
        }
    }
}
