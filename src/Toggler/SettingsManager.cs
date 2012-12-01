using System;
using System.Collections.Generic;

namespace Toggler
{
    public class SettingsManager : ISettingManager
    {
        private static volatile SettingsManager instance;
        private static object syncRoot = new object();
        private readonly HashSet<string> _settingsThatAreTurnedOn;

        private SettingsManager()
        {
            _settingsThatAreTurnedOn = new HashSet<string>();
        }

        public static SettingsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new SettingsManager();
                    }
                }

                return instance;
            }
        }

        public bool IsOn(string appSettingKeyForFeature)
        {
            return _settingsThatAreTurnedOn.Contains(appSettingKeyForFeature);
        }

        public void TurnOn(string appSettingKeyForFeature)
        {
            _settingsThatAreTurnedOn.Add(appSettingKeyForFeature);
        }

        public void TurnOff(string appSettingKeyForFeature)
        {
            _settingsThatAreTurnedOn.Remove(appSettingKeyForFeature);
        }
    }
}
