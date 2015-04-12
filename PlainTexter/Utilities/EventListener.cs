using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Input;

namespace PlainTexter.Utilities
{
    public class EventListener
    {
        private const int KEY_CTRL = 0x11;
        private const int KEY_V = 0x56;
        private const int KEY_DOWN = 0;
        private const int KEY_UP = 2;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        
        private PlainTextConfig _config;
        private globalKeyboardHook _gkh = new globalKeyboardHook();

        private Key _key;
        private string _keyMod1;
        private string _keyMod2;
        private string _keyMod3;

        public EventListener(PlainTextConfig config)
        {
            // Read in the config
            _config = config;

            // Hardcode the keys
            _key = Key.V;
            _keyMod1 = "WIN";
            _keyMod2 = "";
            _keyMod3 = "";
            
            // Add key to listen for
            _gkh.HookedKeys.Add(_key);

            // Listen for keyboard events
            _gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }

        // Handle key down events
        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {            
            if (GetTriggerStatus())
            {
                if (_config.PlaySound)
                {
                    SoundManager.PlaySound();
                }
                
                _gkh.unhook();

                try
                {
                    ClipboardManager.UpdateClipboardToPlainText();
                    SimulateCtrlV();
                }
                catch { }

                _gkh.hook();
            }
        }

        private bool GetTriggerStatus()
        {
            bool condition1 = false;
            bool condition2 = false;
            bool condition3 = false;

            if (GetKeyModResult(_keyMod1))
            {
                condition1 = true;
            }
            if (GetKeyModResult(_keyMod2))
            {
                condition2 = true;
            }
            if (GetKeyModResult(_keyMod3))
            {
                condition3 = true;
            }

            if (condition1 && condition2 && condition3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GetKeyModResult(string keyname)
        {
            if(keyname == "")
            {
                return true;
            }
            else if(keyname == "WIN" && (Keyboard.IsKeyDown(Key.LWin) || Keyboard.IsKeyDown(Key.RWin)))
            {
                return true;
            }

            return false;
        }

        // Send keyboard events to simulate Ctrl-V
        private void SimulateCtrlV()
        {
            keybd_event(KEY_CTRL, 0, KEY_DOWN, 0);
            keybd_event(KEY_V, 0, KEY_DOWN, 0);
            keybd_event(KEY_V, 0, KEY_UP, 0);
            keybd_event(KEY_CTRL, 0, KEY_UP, 0);
        }

    }
}
