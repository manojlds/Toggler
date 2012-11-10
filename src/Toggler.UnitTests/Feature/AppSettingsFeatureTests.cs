using NUnit.Framework;
using Toggler.Feature;

namespace Toggler.UnitTests.Feature
{
    [TestFixture]
    class AppSettingsFeatureTests
    {
        private IFeature testFeature;

        private class TestFeature : AppSettingsFeature
        {
            
        }

        private class TestFeatureDisabled : AppSettingsFeature
        {

        }

        private class TestFeatureNotInAppSettings : AppSettingsFeature
        {

        }

        [Test]
        public void FeatureShouldBeEnabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeature();
            Assert.That(testFeature.IsOn(), Is.True);
        }

        [Test]
        public void FeatureShouldBeDisabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeatureDisabled();
            Assert.That(testFeature.IsOn(), Is.False);
        }

        [Test]
        public void FeatureShouldBeDisabledIfNotInAppSettings()
        {
            testFeature = new TestFeatureNotInAppSettings();
            Assert.That(testFeature.IsOn(), Is.False);
        }
    }
}
