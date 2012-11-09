using System.Configuration;

namespace Toggler
{
    public static class ToggledExtensions
    {
        public static bool IsOn(this IToggled toggledFeature)
        {
            var appSettingKeyForToggledFeature = string.Format("{0}.{1}", "Toggler", toggledFeature.GetType().Name);
            return ConfigurationManager.AppSettings[appSettingKeyForToggledFeature] == "true";
        }
    }

}