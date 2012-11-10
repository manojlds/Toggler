using System.Configuration;
using Toggler.Feature;

namespace Toggler
{
    public static class ToggledExtensions
    {
        public static bool IsOn(this IToggled toggledFeature)
        {
            var appSettingKeyForToggledFeature = string.Format("{0}.{1}", "Toggler", toggledFeature.GetType().Name);
            return ConfigurationManager.AppSettings[appSettingKeyForToggledFeature] == "true";
        }

        public static bool IsFeatureOn<T>(this IToggled<T> toggledFeature) where T : IFeature, new()
        {
            return new T().IsOn();
        }
    }

}