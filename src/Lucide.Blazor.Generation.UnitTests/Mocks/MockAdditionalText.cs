using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace Lucide.Blazor.Generation.UnitTests.Mocks;
internal sealed class MockAdditionalText : AdditionalText
{
    private readonly string _path;
    private readonly string _content;

    public override string Path => _path;

    public MockAdditionalText(string? path, string? content)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentNullException(nameof(path));

        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentNullException(nameof(content));

        _path = path;
        _content = content;
    }

    public override SourceText? GetText(CancellationToken cancellationToken = default)
        => SourceText.From(_content);
}
