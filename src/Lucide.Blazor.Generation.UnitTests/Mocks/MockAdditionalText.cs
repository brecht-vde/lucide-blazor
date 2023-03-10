using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Lucide.Blazor.Generation.UnitTests.Mocks;
internal sealed class MockAdditionalText : AdditionalText
{
    private readonly string? _path;
    private readonly string? _text;

    public override string Path => _path!;

    public MockAdditionalText(string? path, string? text)
    {
        _path = path;
        _text = text;
    }

    public override SourceText? GetText(CancellationToken cancellationToken = default)
        => string.IsNullOrWhiteSpace(_text) ? null : SourceText.From(_text);
}
