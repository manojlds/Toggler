# Toggler #

Feature toggling library for .NET.

**How to get it?**

Toggler is available through the Nuget Package Manager.

Or, you can build it from source.

**How to use it?**

To enable toggling at the class level, implement the `IToggled` interface:
```csharp
public class TestFeature : IToggled
{
    public bool IsFeatureEnabled()
    {
        return this.IsOn();
    }
}
```

Within such a class, you can do `this.IsOn()` to see if the feature is enabled and take appropriate action.

You can enable or disable the features in the AppSettings:
```xml
<appSettings>
    <add key="Toggler.TestFeature" value="true"/>
    <add key="Toggler.TestFeatureDisabled" value="false"/>
</appSettings>
```    

`TestFeature` and `TestFeatureDisabled` refers to classes that are feature toggled.

To add a feature, extend `AppSettingsFeature`.
```csharp
public class TestToggleFeature : AppSettingsFeature
{

}
```

Enable or disable features in the AppSettings:
```xml
<appSettings>
    <add key="Toggler.Feature.TestToggleFeature" value="true"/>
</appSettings>
```
Note the `Toggler.Feature.` prefix.

To enable a class to use feature toggling with the feature you created, implement the `IToggled<IFeature>` interface:
```csharp
public class TestToggledWithFeature : IToggled<TestToggleFeature>
{

}
```

You can now do `this.IsFeatureOn<TestToggleFeature>` to see if the feature `TestToggleFeature` is available in `TestToggledWithFeatures`

You can implement both `IToggled` and `IToggled<TestToggleFeature>`

Refer to the tests for impementation.

**How to test it?**

You can use the Toggler.TestHelper Nuget package to test toggles in your code. A typical test for toggling with feature would like below:
```csharp
public class ToggledWithFeature : IToggled<Feature>
{
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
```

You setup the test context with `toggledWithFeature.SetUpToggledWithFeature(true)` and make necessary action and insert within it.

The test helper makes use of Microsoft Fakes. If you are already using Fakes, you may wish to test directly with it. You can also, of course, choose to test toggles in your own way.