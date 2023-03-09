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

        // Act
        var target = Render.Component(template: component);

        // Assert
        return Verify(target);
    }
}
