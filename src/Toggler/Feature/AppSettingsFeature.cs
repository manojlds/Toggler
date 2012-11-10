using System.Configuration;

namespace Toggler.Feature
{
    public class AppSettingsFeature : IFeature
    {
        public bool IsOn()
        {
            var appSettingKeyForFeature = string.Format("{0}.{1}", "Toggler.Feature", GetType().Name);
            return ConfigurationManager.AppSettings[appSettingKeyForFeature] == "true";
        }
    }
}
