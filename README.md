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

`TestFeature` and `TestFeatureDisabled` refers to classes that are feature toggled.

To add a feature, extend `AppSettingsFeature`.

    public class TestToggleFeature : AppSettingsFeature
    {

    }

Enable or disable features in the AppSettings:

    <appSettings>
        <add key="Toggler.Feature.TestToggleFeature" value="true"/>
    </appSettings>

Note the `Toggler.Feature.` prefix.

To enable a class to use feature toggling with the feature you created, implement the `IToggled<IFeature>` interface:

    public class TestToggledWithFeature : IToggled<TestToggleFeature>
    {

    }

You can now do `this.IsFeatureOn<TestToggleFeature>` to see if the feature `TestToggleFeature` is available in `TestToggledWithFeatures`

You can implement both `IToggled` and `IToggled<TestToggleFeature>`

Refer to the tests for impementation.
