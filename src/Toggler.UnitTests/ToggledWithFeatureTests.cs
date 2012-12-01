using NUnit.Framework;
using Toggler.Feature;

namespace Toggler.UnitTests
{
    [TestFixture]
    public class ToggledWithFeatureTests
    {
        private class TestFluentToggleFeature : AppSettingsFeature
        {
            public TestFluentToggleFeature()
                : base(false) {}
        }

        private class TestFluentToggledWithFeature : IToggled<TestFluentToggleFeature>
        {
        }

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

        [Test]
        public void ToggledWithFluentFeatureShouldBeEnabled()
        {
            var testToggledWithFeature = new TestFluentToggledWithFeature();
            testToggledWithFeature.On();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.True);
        }

        [Test]
        public void ToggledWithFluentFeatureShouldBeDisabledByDefault()
        {
            var testToggledWithFeature = new TestFluentToggledWithFeature();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.False);
        }

        [Test]
        public void ToggledWithFluentFeatureShouldBeEnabledAndDisabled()
        {
            var testToggledWithFeature = new TestFluentToggledWithFeature();
            testToggledWithFeature.On();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.True);
            testToggledWithFeature.Off();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.False);
        }

        [Test]
        public void ToggledWithFluentFeatureShouldBeFluent()
        {
            var testToggledWithFeature = new TestFluentToggledWithFeature();
            testToggledWithFeature.On().Off();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.False);
            testToggledWithFeature.Off().On();
            Assert.That(testToggledWithFeature.IsFeatureOn(), Is.True);
        }
    }
}