using System;
using Microsoft.QualityTools.Testing.Fakes;
using Toggler.Feature;

namespace Toggler.TestHelper
{
    public static class TogglerFake
    {
        private static IDisposable _shimsContext;

        public static IDisposable SetUpToggled(this IToggled toggled, bool toggle)
        {
            _shimsContext = ShimsContext.Create();
            Fakes.ShimToggledExtensions.IsOnIToggled = toggled1 => toggled == toggled1 && toggle;
            return _shimsContext;
        }
    
        public static IDisposable SetUpToggledWithFeature<T>(this IToggled<T> toggled, bool toggle) where T : IFeature, new()
        {
            _shimsContext = ShimsContext.Create();
            Fakes.ShimToggledExtensions.IsFeatureOnOf1IToggledOfM0<T>(toggled1 => toggled1 == toggled && toggle);
            return _shimsContext;
        }
    }
}
