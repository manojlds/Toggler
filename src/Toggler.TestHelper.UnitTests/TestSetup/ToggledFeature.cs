namespace Toggler.TestHelper.UnitTests.TestSetup
{
    public class ToggledFeature : IToggled
    {
        public int SomeProcessing()
        {
            return this.IsOn() ? 1 : 2;
        }
    }
}
