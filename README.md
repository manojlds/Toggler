# Toggler #

Feature toggling library for .NET.

**How to get it?**

Toggler is available through the Nuget Package Manager.

Or, you can build it from source.

**How to use it?**

To enable toggling at the class level, implement the `IToggled` interface:

    public class TestFeature : IToggled
    {
        public bool IsFeatureEnabled()
        {
            return this.IsOn();
        }
    }

Within such a class, you can do `this.IsOn()` to see if the feature is enabled and take appropriate action.

You can enable or disable the features in the AppSettings:

    <appSettings>
        <add key="Toggler.TestFeature" value="true"/>
        <add key="Toggler.TestFeatureDisabled" value="false"/>
    </appSettings>

`TestFeature` and `TestFeatureDisabled` refers to classes are feature toggled.