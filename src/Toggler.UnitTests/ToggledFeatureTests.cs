using NUnit.Framework;

namespace Toggler.UnitTests
{
    [TestFixture]
    public class ToggledFeatureTests
    {
        private IToggled testFeature;

        private class TestFeature : IToggled
        {
            
        }

        private class TestFeatureDisabled : IToggled
        {
            
        }

        private class TestFeatureNotInAppSettings : IToggled
        {

        }

        [Test]
        public void ToggledFeatureShouldBeEnabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeature();
            Assert.That(testFeature.IsOn(), Is.True);
        }

        [Test]
        public void ToggledFeatureShouldBeDisabledIfConfiguredSoInAppSettings()
        {
            testFeature = new TestFeatureDisabled();
            Assert.That(testFeature.IsOn(), Is.False);
        }

        [Test]
        public void ToggledFeatureIsDisableIfNotMentionedInAppSettings()
        {
            testFeature = new TestFeatureNotInAppSettings();
            Assert.That(testFeature.IsOn(), Is.False);
        }
    }
}
