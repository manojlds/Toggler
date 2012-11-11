using NUnit.Framework;
using Toggler.TestHelper.UnitTests.TestSetup;

namespace Toggler.TestHelper.UnitTests
{
    [TestFixture]
    class TogglerFakeTests
    {
        [Test]
        public void ShouldBeAbleToSetupToggledToOn()
        {
            var toggledFeature = new ToggledFeature();
            using (toggledFeature.SetUpToggled(true))
            {
                Assert.That(toggledFeature.IsOn(), Is.True);
            }
        }

        [Test]
        public void ShouldBeAbleToSetupToggledToOff()
        {
            var toggledFeature = new ToggledFeature();
            using (toggledFeature.SetUpToggled(false))
            {
                Assert.That(toggledFeature.IsOn(), Is.False);
            }
        }

        [Test]
        public void ShouldBeAbleToSetupToggleWithFeatureToOn()
        {
            var toggledWithFeature = new ToggledWithFeature();
            using (toggledWithFeature.SetUpToggledWithFeature(true))
            {
                Assert.That(toggledWithFeature.IsFeatureOn(), Is.True);
            }
        }

        [Test]
        public void ShouldBeAbleToSetupToggleWithFeatureToOff()
        {
            var toggledWithFeature = new ToggledWithFeature();
            using (toggledWithFeature.SetUpToggledWithFeature(false))
            {
                Assert.That(toggledWithFeature.IsFeatureOn(), Is.False);
            }
        }

        [Test]
        public void ShouldBeAbleToSetupToggleWithFeatureToOnForOneAmongstMany()
        {
            var toggledWithMultipleFeatures = new ToggledWithMultipleFeatures();
            using (toggledWithMultipleFeatures.SetUpToggledWithFeature<Feature2>(true))
            {
                Assert.That(toggledWithMultipleFeatures.IsFeatureOn<Feature2>(), Is.True);
            }
        }

        [Test]
        public void ShouldBeAbleToSetupToggleWithFeatureToOnForAllFeatures()
        {
            var toggledWithMultipleFeatures = new ToggledWithMultipleFeatures();
            using (toggledWithMultipleFeatures.SetUpToggledWithFeature<Feature2>(true))
            {
                using (toggledWithMultipleFeatures.SetUpToggledWithFeature<TestSetup.Feature>(true))
                {
                    Assert.That(toggledWithMultipleFeatures.IsFeatureOn<TestSetup.Feature>(), Is.True);
                }
            }
        }
    }
}
