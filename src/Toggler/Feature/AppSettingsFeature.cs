using System;
using System.Configuration;

namespace Toggler.Feature
{
    public class AppSettingsFeature : IFeature
    {
        private readonly ISettingManager _settingManager;
        private readonly bool _useConfigurationFile;

        public AppSettingsFeature()
        {
            _settingManager = SettingsManager.Instance;
            _useConfigurationFile = true;
        }

        public AppSettingsFeature(bool useConfigurationFile)
        {
            _settingManager = SettingsManager.Instance;
            _useConfigurationFile = useConfigurationFile;
        }

        public AppSettingsFeature(bool useConfigurationFile, ISettingManager settingManager)
        {
            _settingManager = settingManager;
            _useConfigurationFile = useConfigurationFile;
        }

        public bool IsOn()
        {
            var appSettingKeyForFeature = string.Format("{0}.{1}", "Toggler.Feature", GetType().Name);

            if (!_useConfigurationFile)
                return _settingManager.IsOn(appSettingKeyForFeature);

            return ConfigurationManager.AppSettings[appSettingKeyForFeature] == "true";
        }

        public IFeature On()
        {
            var appSettingKeyForFeature = string.Format("{0}.{1}", "Toggler.Feature", GetType().Name);

            if (!_useConfigurationFile)
                _settingManager.TurnOn(appSettingKeyForFeature);
            else
                throw new ArgumentNullException("The setting manager must be specified");

            return this;
        }

        public IFeature Off()
        {
            var appSettingKeyForFeature = string.Format("{0}.{1}", "Toggler.Feature", GetType().Name);

            if (!_useConfigurationFile)
                _settingManager.TurnOff(appSettingKeyForFeature);
            else
                throw new ArgumentNullException("The setting manager must be specified");

            return this;
        }
    }
}
