using Microsoft.Win32;
using System.Reflection;

namespace PlainTexter.Utilities
{
    public class PlainTextConfig
    {
        private const string RunAtStatupKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string AppKeyPath = @"Software\PlainTexter";

        public bool RunAtStatup { get; set; }
        public bool PlaySound { get; set; }
        public string SoundPath { get; set; }


        public PlainTextConfig()
        {
            // Load default settings
            PlaySound = true;
            RunAtStatup = false;
            SoundPath = "{Default}";
        }

        public PlainTextConfig(bool ReadFromRegistry)
            : this()
        {
            if (ReadFromRegistry)
            {
                UpdateFromRegistry();
            }
        }

        public void UpdateFromNewConfig(PlainTextConfig newconfig)
        {
            if (RunAtStatup != newconfig.RunAtStatup)
            {
                RunAtStatup = newconfig.RunAtStatup;

                if (newconfig.RunAtStatup)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(RunAtStatupKeyPath, true);
                    key.SetValue("PlainTexter", Assembly.GetExecutingAssembly().Location, RegistryValueKind.String);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(RunAtStatupKeyPath, true);
                    key.DeleteValue("PlainTexter");
                }
            }

            if (PlaySound != newconfig.PlaySound)
            {
                PlaySound = newconfig.PlaySound;

                EnsureAppKeyExists();

                if (newconfig.PlaySound)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(AppKeyPath, true);
                    key.SetValue("PlaySound", "true", RegistryValueKind.String);
                }
                else
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey(AppKeyPath, true);
                    key.SetValue("PlaySound", "false", RegistryValueKind.String);
                }
            }
        }

        private void UpdateFromRegistry()
        {
            RunAtStatup = GetRegSetting(RunAtStatupKeyPath, "PlainTexter", Assembly.GetExecutingAssembly().Location);

            if (EnsureAppKeyExists())
            {
                PlaySound = GetRegSetting(AppKeyPath, "PlaySound", "true");
            }
        }

        private bool EnsureAppKeyExists()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(AppKeyPath);

            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(AppKeyPath);
                key.SetValue("PlaySound", "true", RegistryValueKind.String);
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool GetRegSetting(string keypath, string value, string truematch)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(keypath);

            if (key != null)
            {
                string property = (string)key.GetValue(value);

                if (property != null && property.ToLower() == truematch.ToLower())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        


    }
}
