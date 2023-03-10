using Bunit;
using Lucide.Blazor.Components;
using Lucide.Blazor.Data;
using Lucide.Blazor.UnitTests.Utilities;
using VerifyTests.Blazor;

namespace Lucide.Blazor.UnitTests;

[UsesVerify]
public sealed class IconTests
{
    [Fact]
    internal Task VerifyIconSet()
    {
        // Arrange
        var component = new MockIconSetComponent();
        var target = Render.Component(template: component);

        // Assert
        return Verify(target);
    }

    [Fact]
    internal Task VerifyAdditionalAttributes()
    {
        // Arrange
        var component = new Icon()
        {
            Name = IconSet.Icons.Keys.First()
        };

        component.Attributes.Add("custom-attribute", "custom-attribute-value");

        var target = Render.Component(template: component);

        // Assert
        return Verify(target);
    }

    [Fact]
    internal Task VerifyClassAttribute()
    {
        // Arrange
        var component = new Icon()
        {
            Name = IconSet.Icons.Keys.First(),
            Css = "custom-class"
        };

        var target = Render.Component(template: component);

        // Assert
        return Verify(target);
    }

    [Fact]
    internal void RenderIcon_UnknownIconName_Throws()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var action = () => ctx.RenderComponent<Icon>(builder => builder.Add(p => p.Name, "n/a"));

        // Assert
        Assert.Throws<KeyNotFoundException>(action);
    }

    [Fact]
    internal void RenderIcon_AttributesNull_DoesNotThrow()
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        ctx.RenderComponent<Icon>(builder => 
            builder
            .Add(p => p.Name, IconSet.Icons.Keys.First())
            .Add(p => p.Attributes, null));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    internal void RenderIcon_NameIsNullOrWhiteSpace_Throws(string name)
    {
        // Arrange
        using var ctx = new TestContext();

        // Act
        var action = () =>ctx.RenderComponent<Icon>(builder => builder.Add(p => p.Name, name));

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }
}
