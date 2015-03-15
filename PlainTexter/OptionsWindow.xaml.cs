using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PlainTexter.Utilities;
using System.IO;
using System.Data;

namespace PlainTexter
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        private EventListener _eventListener;
        private PlainTextConfig _config;

        public OptionsWindow(EventListener eventListener, PlainTextConfig config)
        {
            InitializeComponent();
            ShowInTaskbar = false;

            _eventListener = eventListener;
            _config = config;

            if (_config.RunAtStatup)
            {
                RunAtStartupCheckbox.IsChecked = true;
            }

            if (_config.PlaySound)
            {
                PlaySoundCheckbox.IsChecked = true;
            }

            DebugTextBlock.Text = _eventListener.GetDebugStatus();
        }



        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                if (ViewerTab.IsSelected)
                {
                    ViewerRefreshButton_Click(null, null);
                }
                else if(DebugTab.IsSelected)
                {
                    DebugRefreshButton_Click(null, null);
                }
            }
        }

        private void SaveSettingshButton_Click(object sender, RoutedEventArgs e)
        {
            PlainTextConfig newconfig = new PlainTextConfig();

            if ((bool)RunAtStartupCheckbox.IsChecked)
            {
                newconfig.RunAtStatup = true;
            }
            else
            {
                newconfig.RunAtStatup = false;
            }

            if ((bool)PlaySoundCheckbox.IsChecked)
            {
                newconfig.PlaySound = true;
            }
            else
            {
                newconfig.PlaySound = false;
            }

            _config.UpdateFromNewConfig(newconfig);
        }

        private void ViewerRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            // Get data format
            string dataFormat = ClipboardManager.GetClipboardDataFormat();
            DataFormatTextBlock.Text = dataFormat;

            // Hide everything
            ViewerWebBrowser.Visibility = Visibility.Hidden;
            ViewerTextBox.Visibility = Visibility.Hidden;
            ViewerRichTextBox.Visibility = Visibility.Hidden;
            ViewerDataGrid.Visibility = Visibility.Hidden;

            // Display data
            if (dataFormat == "Text: CommaSeparatedValue")
            {
                try
                {
                    ViewerDataGrid.Visibility = Visibility.Visible;
                    ViewerDataGrid.ItemsSource = GetDataTableFromString(ClipboardManager.GetClipboardCommaSeparatedValue()).DefaultView;
                    
                }
                catch
                {
                    ViewerDataGrid.Visibility = Visibility.Hidden;
                    ViewerTextBox.Visibility = Visibility.Visible;
                    ViewerTextBox.Text = ClipboardManager.GetClipboardTextData();
                }
            }
            else if (dataFormat == "Text: Html")
            {
                ViewerWebBrowser.Visibility = Visibility.Visible;
                ViewerWebBrowser.NavigateToString(ClipboardManager.GetClipboardHtml());
            }
            else if (dataFormat == "Text: Rtf")
            {
                ViewerRichTextBox.Visibility = Visibility.Visible;
                ViewerRichTextBox.Selection.Load(new MemoryStream(UTF8Encoding.Default.GetBytes(ClipboardManager.GetClipboardRtf())), DataFormats.Rtf);
            }
            else if (dataFormat == "Text: UnicodeText")
            {
                ViewerTextBox.Visibility = Visibility.Visible;
                ViewerTextBox.Text = ClipboardManager.GetClipboardTextData();
            }
            else if (dataFormat == "Text: Text")
            {
                ViewerTextBox.Visibility = Visibility.Visible;
                ViewerTextBox.Text = ClipboardManager.GetClipboardTextData();
            }
            else
            {
                ViewerTextBox.Visibility = Visibility.Visible;
                ViewerTextBox.Text = ClipboardManager.GetClipboardTextData();
            }
        }

        private void DebugRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            DebugTextBlock.Text = _eventListener.GetDebugStatus();
        }

        private void ResetKeysButton_Click(object sender, RoutedEventArgs e)
        {
            _eventListener.ResetKeys();
        }





        private DataTable GetDataTableFromString(string input)
        {
            DataTable dt = new DataTable();
            int columnCount = 0;

            string[] lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            foreach(string line in lines)
            {
                string[] columns = line.Split(',');

                if (columnCount < columns.Count())
                {
                    columnCount = columns.Count();
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                dt.Columns.Add(i.ToString());
            }

            foreach (string line in lines)
            {
                if(line.Trim() != "")
                {
                    string[] columns = line.Split(',');

                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < columnCount; i++)
                    {
                        dr[i] = columns[i];
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }



        
    }
}
