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

        private Key _key1;
        private Key _key2;
        private Key _key3;
        private Key _key4;

        private bool _key1Down;
        private bool _key2Down;
        private bool _key3Down;
        private bool _key4Down;        

        public EventListener(PlainTextConfig config)
        {
            // Read in the config
            _config = config;

            // Hardcode the keys
            _key1 = Key.LWin;
            _key2 = Key.V;
            _key3 = Key.None;
            _key4 = Key.None;
            
            // Add keys to listen for
            if (_key1 != Key.None)
            {
                _gkh.HookedKeys.Add(_key1);
            }

            if (_key2 != Key.None)
            {
                _gkh.HookedKeys.Add(_key2);
            }

            if (_key3 != Key.None)
            {
                _gkh.HookedKeys.Add(_key3);
            }

            if (_key4 != Key.None)
            {
                _gkh.HookedKeys.Add(_key4);
            }

            // Listen for keyboard events
            _gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            _gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);

            // Listen for unlock events
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(OnSessionSwitch);
        }
        
        public string GetDebugStatus()
        {
            string output = "";
            string keysListening = "";
            string keysDown = "";

            if (_key1 != Key.None)
            {
                keysListening += " - Key1: " + _key1 + "\r\n";
            }
            if (_key2 != Key.None)
            {
                keysListening += " - Key2: " + _key2 + "\r\n";
            }
            if (_key3 != Key.None)
            {
                keysListening += " - Key3: " + _key3 + "\r\n";
            }
            if (_key4 != Key.None)
            {
                keysListening += " - Key4: " + _key4 + "\r\n";
            }

            if (_key1Down)
            {
                keysDown += " - Key1\r\n";
            }
            if (_key2Down)
            {
                keysDown += " - Key2\r\n";
            }
            if (_key3Down)
            {
                keysDown += " - Key3\r\n";
            }
            if (_key4Down)
            {
                keysDown += " - Key4\r\n";
            }

            if (keysListening != "")
            {
                output += "Listening for keys:\r\n" + keysListening + "\r\n";
            }
            else
            {
                output += "Not listening for any keys.\r\n\r\n";
            }

            if (keysDown != "")
            {
                output += "Down keys:\r\n" + keysDown + "\r\n";
            }
            else
            {
                output += "No keys are down.";
            }

            return output;
        }

        public void ResetKeys()
        {
            _key1Down = false;
            _key2Down = false;
            _key3Down = false;
            _key4Down = false;
        }

        // Capture logon, logoff, lock, unlock events
        private void OnSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            // If the user just unlocked the computer, assume no keys are held
            if (e.Reason.ToString() == "SessionUnlock")
            {
                ResetKeys();
            }
        }

        // Handle key up events
        private void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            if (GetTriggerStatus() && _config.PlaySound)
            {
                SoundManager.PlaySound();
            }

            if (_key1 != Key.None && e.Key == _key1)
            {
                _key1Down = false;
            }
            else if (_key2 != Key.None && e.Key == _key2)
            {
                _key2Down = false;
            }
            else if (_key3 != Key.None && e.Key == _key3)
            {
                _key3Down = false;
            }
            else if (_key4 != Key.None && e.Key == _key4)
            {
                _key4Down = false;
            }
        }

        // Handle key down events
        private void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            if (_key1 != Key.None && e.Key == _key1)
            {
                _key1Down = true;
            }
            else if (_key2 != Key.None && e.Key == _key2)
            {
                _key2Down = true;
            }
            else if (_key3 != Key.None && e.Key == _key3)
            {
                _key3Down = true;
            }
            else if (_key4 != Key.None && e.Key == _key4)
            {
                _key4Down = true;
            }
            
            if (GetTriggerStatus())
            {
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
            bool condition4 = false;

            if (_key1 == Key.None || _key1Down)
            {
                condition1 = true;
            }
            if (_key2 == Key.None || _key2Down)
            {
                condition2 = true;
            }
            if (_key3 == Key.None || _key3Down)
            {
                condition3 = true;
            }
            if (_key4 == Key.None || _key4Down)
            {
                condition4 = true;
            }

            if (condition1 && condition2 && condition3 && condition4)
            {
                return true;
            }
            else
            {
                return false;
            }
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
