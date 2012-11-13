using System;
using Microsoft.QualityTools.Testing.Fakes;
using Toggler.Feature;

namespace Toggler.TestHelper
{
    public static class TogglerFake
    {
        private static TogglerShimsContext _togglerShimsContext;

        private class TogglerShimsContext : IDisposable
        {
            public readonly IDisposable shimsContext;

            private static int _level;

            public TogglerShimsContext()
            {
                shimsContext = ShimsContext.Create();
                Created = true;
                _level++;
            }

            public bool Created { get; private set; }

            public void Dispose()
            {
                _level--;
                if (_level != 0) return;

                shimsContext.Dispose();
                Created = false;
            }
        }

        public static IDisposable SetUpToggled(this IToggled toggled, bool toggle)
        {
            if (_togglerShimsContext == null || !_togglerShimsContext.Created)
            {
                _togglerShimsContext = new TogglerShimsContext();
            }
            var shimsContext = _togglerShimsContext.shimsContext;
            Fakes.ShimToggledExtensions.IsOnIToggled = toggled1 => toggled == toggled1 && toggle;
            return _togglerShimsContext;
        }

        public static IDisposable SetUpToggledWithFeature<T>(this IToggled<T> toggled, bool toggle) where T : IFeature, new()
        {
            if (_togglerShimsContext == null || !_togglerShimsContext.Created)
            {
                _togglerShimsContext = new TogglerShimsContext();
            }
            var shimsContext = _togglerShimsContext.shimsContext;
            Fakes.ShimToggledExtensions.IsFeatureOnOf1IToggledOfM0<T>(toggled1 => toggled1 == toggled && toggle);
            return _togglerShimsContext;
        }
    }
}
