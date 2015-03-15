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
using System.Windows.Navigation;
using System.Windows.Shapes;


using PlainTexter.Utilities;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace PlainTexter
{
    class Main : Window
    {
        private EventListener _eventListener;
        private Window _optionsWindow;
        private PlainTextConfig _config;
        private NotifyIcon _trayIcon;

        public Main()
        {
            // Run in the background
            Visibility = System.Windows.Visibility.Hidden;
            ShowInTaskbar = false;
            SetupTaskTrayIcon();

            // Load the current config
            _config = new PlainTextConfig();
            _config.UpdateFromRegistry();
            _eventListener = new EventListener(_config);
        }

        private void SetupTaskTrayIcon()
        {
            // Build the icon menu
            System.Windows.Forms.ContextMenu trayMenu = new System.Windows.Forms.ContextMenu();
            System.Windows.Forms.MenuItem item = new System.Windows.Forms.MenuItem("Options", OnOptions);
            item.DefaultItem = true;
            trayMenu.MenuItems.Add(item);
            trayMenu.MenuItems.Add("Exit", OnExit);

            // Build the tray icon
            _trayIcon = new NotifyIcon();
            _trayIcon.Text = "PlainTexter";
            _trayIcon.Icon = new Icon(PlainTexter.Resource.icon, 40, 40);
            _trayIcon.ContextMenu = trayMenu;
            _trayIcon.DoubleClick += trayIcon_DoubleClick;
            _trayIcon.Visible = true;
        }

        
        // When the icon is double clicked, open the configure form
        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            OnOptions(sender, e);
        }

        // Open handle requests to edit the settings
        private void OnOptions(object sender, EventArgs e)
        {
            // Check that the Configure window isn't already open
            if (_optionsWindow == null)
            {
                _optionsWindow = new OptionsWindow(_eventListener, _config);
                _optionsWindow.Show();
                _optionsWindow.Closed += _configureWindow_Closed;
            }
        }

        private void _configureWindow_Closed(object sender, EventArgs e)
        {
            _optionsWindow = null;
        }
        
        private void OnExit(object sender, EventArgs e)
        {
            _trayIcon.Visible = false;
            _trayIcon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }


    }
}
