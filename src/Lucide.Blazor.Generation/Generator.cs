using Microsoft.CodeAnalysis;
using System.Text;
using System.Xml.Linq;

namespace Lucide.Blazor.Generation;

[Generator]
public class Generator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext ctx)
    {
        var files = ctx.AdditionalTextsProvider.Where(file => file.Path.EndsWith(".svg"));

        var iconsProvider = files.Select((file, cancel)
            => (
                Name: Path.GetFileNameWithoutExtension(file.Path),
                Svg: file.GetText(cancel)?.ToString()
            )).Collect();

        ctx.RegisterSourceOutput(iconsProvider, (spc, iconsArray) =>
        {
            var sb = new StringBuilder();

            foreach (var (Name, Svg) in iconsArray)
            {
                var value = Extract(Name, Svg);
                sb.AppendLine($$"""{ "{{Name}}", {{"\"\"\""}}{{value}}{{"\"\"\""}} },""");
            }

            var fileTemplate =
                $$"""
                namespace Lucide.Blazor.Data;

                public static class IconSet
                {
                    public static IReadOnlyDictionary<string, string> Icons = new Dictionary<string, string>()
                    {
                        {{sb}}
                    };
                }
                """;

            spc.AddSource("IconSet.g.cs", fileTemplate);
        });
    }

    private string Extract(string? name, string? value)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new ArgumentNullException(nameof(name), "The provided icon does not have a name.");

        if (string.IsNullOrWhiteSpace(value)) 
            throw new ArgumentNullException(nameof(value), $"The provided icon with name '{name}', does not have a valid value, please check the file contents.");

        var svg = XDocument.Parse(value);

        if (svg is null) 
            throw new NullReferenceException(nameof(svg));

        var elements = svg.Root.Descendants()
            .Select(element =>
            {
                element.Name = element.Name.LocalName;
                return element.ToString(SaveOptions.DisableFormatting);
            });

        var paths = string.Concat(elements);

        return paths;
    }
}