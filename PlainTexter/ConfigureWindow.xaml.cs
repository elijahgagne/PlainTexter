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

namespace PlainTexter
{
    /// <summary>
    /// Interaction logic for ConfigureWindow.xaml
    /// </summary>
    public partial class ConfigureWindow : Window
    {
        private EventListener _eventListener;
        private PlainTextConfig _config;

        public ConfigureWindow(EventListener eventListener, PlainTextConfig config)
        {
            InitializeComponent();

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

        private void DebugRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            DebugTextBlock.Text = _eventListener.GetDebugStatus();
        }

        private void ResetKeysButton_Click(object sender, RoutedEventArgs e)
        {
            _eventListener.ResetKeys();
        }
    }
}
