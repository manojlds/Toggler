using Toggler.Feature;

namespace Toggler
{
    public interface IToggled
    {
    }

    public interface IToggled<T> where T : IFeature
    {
        
    }
}
