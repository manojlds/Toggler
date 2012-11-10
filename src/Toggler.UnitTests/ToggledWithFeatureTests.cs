using NUnit.Framework;
using Toggler.Feature;

namespace Toggler.UnitTests
{
    [TestFixture]
    public class ToggledWithFeatureTests
    {
        private class TestToggleFeature : AppSettingsFeature
        {

        }

        private class TestToggledWithFeature : IToggled<TestToggleFeature>
        {

        }

        private class TestToggledWithFeatureAndToggled : IToggled, IToggled<TestToggleFeature>
        {
            
        }

        [Test]
        public void ToggledWithFeatureShouldBeEnabled()
        {
            var testToggledWithFeature = new TestToggledWithFeature();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.True);
        }

        [Test]
        public void ToggledWithFeatureShouldBeEnabledIrrespectiveOfBeingToggled()
        {
            var testToggledWithFeatureAndToggled = new TestToggledWithFeatureAndToggled();
            Assert.That(testToggledWithFeatureAndToggled.IsFeatureOn(), Is.True);
        }

    }
}