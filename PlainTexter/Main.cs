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
        private Window _configureWindow;
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
            System.Windows.Forms.MenuItem item = new System.Windows.Forms.MenuItem("Configure", OnConfigure);
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
            OnConfigure(sender, e);
        }

        // Open handle requests to edit the settings
        private void OnConfigure(object sender, EventArgs e)
        {
            // Check that the Configure window isn't already open
            if (_configureWindow == null)
            {
                _configureWindow = new ConfigureWindow(_eventListener, _config);
                _configureWindow.Show();
                _configureWindow.Closed += _configureWindow_Closed;
            }
        }

        private void _configureWindow_Closed(object sender, EventArgs e)
        {
            _configureWindow = null;
        }
        
        private void OnExit(object sender, EventArgs e)
        {
            _trayIcon.Visible = false;
            _trayIcon.Dispose();
            System.Windows.Application.Current.Shutdown();
        }





        /*
        private void OnReset(object sender, EventArgs e)
        {
            _eventListener.ResetKeys();
        }

        private void OnDebug(object sender, EventArgs e)
        {
            var status = _eventListener.GetStatus();
            System.Windows.MessageBox.Show(status);
        }
        
        private void OnConfigure(object sender, EventArgs e)
        {
            // Check that the Settings form isn't already open
            if (SettingsOpen == false)
            {
                SettingsOpen = true;
                Rectangle workingArea = Screen.GetWorkingArea(this);
                SettingsForm settingsForm = new SettingsForm(config);
                settingsForm.Location = new Point(workingArea.Right - Size.Width - 300, workingArea.Bottom - Size.Height - 200);
                settingsForm.Disposed += settingsForm_Disposed;
                settingsForm.Show();
            }
        }

        // Update tracking that user closed Settings
        private void settingsForm_Disposed(object sender, EventArgs e)
        {
            SettingsOpen = false;
        }
        */




    }
}
