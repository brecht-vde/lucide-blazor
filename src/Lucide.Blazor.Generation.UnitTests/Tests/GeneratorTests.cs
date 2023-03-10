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
    internal Task VerifyGenerator()
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

    private static readonly ImmutableArray<AdditionalText> NullValueIcons = ImmutableArray.Create
    (
        new MockAdditionalText("mock-icon.svg", null) as AdditionalText
    );

    [Fact]
    internal void VerifyGenerator_ValueIsNull_Throws()
    {
        // Arrange
        var generator = new Generator();
        var compilation = CSharpCompilation.Create(nameof(GeneratorTests));
        var driver = CSharpGeneratorDriver.Create(generator) as GeneratorDriver;
        driver = driver.AddAdditionalTexts(NullValueIcons);

        // Act
        driver = driver.RunGenerators(compilation);

        // Assert
        var result = driver.GetRunResult().Results.Any(r => r.Exception != null && r.Exception is ArgumentNullException);
        Assert.True(result);
    }

    private static readonly ImmutableArray<AdditionalText> NonSvg = ImmutableArray.Create
    (
        new MockAdditionalText("mock-file.txt", "mock-text") as AdditionalText
    );

    [Fact]
    internal Task VerifyGenerator_NonSvg_ReturnsEmptyDictionary()
    {
        // Arrange
        var generator = new Generator();
        var compilation = CSharpCompilation.Create(nameof(GeneratorTests));
        var driver = CSharpGeneratorDriver.Create(generator) as GeneratorDriver;
        driver = driver.AddAdditionalTexts(NonSvg);

        // Act
        driver = driver.RunGenerators(compilation);

        // Assert
        return Verify(driver);
    }

    private static readonly ImmutableArray<AdditionalText> NullPath = ImmutableArray.Create
    (
        new MockAdditionalText(null, "mock-text") as AdditionalText
    );

    [Fact]
    internal Task VerifyGenerator_NullPath_ReturnsEmptyDictionary()
    {
        // Arrange
        var generator = new Generator();
        var compilation = CSharpCompilation.Create(nameof(GeneratorTests));
        var driver = CSharpGeneratorDriver.Create(generator) as GeneratorDriver;
        driver = driver.AddAdditionalTexts(NullPath);

        // Act
        driver = driver.RunGenerators(compilation);

        // Assert
        return Verify(driver);
    }
}
