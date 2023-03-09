using Lucide.Blazor.Generation.UnitTests.Mocks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;

namespace Lucide.Blazor.Generation.UnitTests.Tests;

[UsesVerify]
public sealed class GeneratorTests
{
    private static readonly ImmutableArray<AdditionalText> Icons = ImmutableArray.Create
    (
        new MockAdditionalText("mock-icon.svg", """<svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path></path></svg>""") as AdditionalText
    );

    [Fact]
    public Task VerifyGenerator()
    {
        // Arrange
        var generator = new Generator();
        var compilation = CSharpCompilation.Create(nameof(GeneratorTests));
        var driver = CSharpGeneratorDriver.Create(generator) as GeneratorDriver;
        driver = driver.AddAdditionalTexts(Icons);

        // Act
        driver = driver.RunGenerators(compilation);

        // Assert
        return Verify(driver);
    }
}
