using NUnit.Framework;

namespace Toggler.UnitTests
{
    [TestFixture]
    public class ToggledFeatureTests
    {
        private TestFeature testFeature;

        private class TestFeature : IToggled
        {
            public bool IsFeatureEnabled()
            {
                return this.IsOn();
            }
        }

        private class TestFeatureDisabled : TestFeature
        {
            
        }

        [Test]
        public void ToggledFeatureShouldBeEnabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeature();
            Assert.That(testFeature.IsFeatureEnabled(), Is.True);
        }

        [Test]
        public void ToggledFeatureShouldBeDisabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeatureDisabled();
            Assert.That(testFeature.IsFeatureEnabled(), Is.False);
        }
    }
}
