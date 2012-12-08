namespace Toggler.Feature
{
    public interface IFeature
    {
        bool IsOn();
        IFeature On();
        IFeature Off();
    }
}
