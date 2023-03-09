using Lucide.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Lucide.Blazor.Components;

public class Icon : ComponentBase
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        var icon = IconSet.Icons.FirstOrDefault(i => i.Key.Equals(Name, StringComparison.OrdinalIgnoreCase));

        if (icon.Equals(default(KeyValuePair<string, string>))) throw new KeyNotFoundException($"Could not find icon with name {Name}.");

        builder.OpenElement(0, "svg");
        builder.AddAttribute(1, "xmlns", "http://www.w3.org/2000/svg");
        builder.AddAttribute(2, "width", Width);
        builder.AddAttribute(3, "height", Height);
        builder.AddAttribute(4, "viewBox", ViewBox);
        builder.AddAttribute(5, "fill", Fill);
        builder.AddAttribute(6, "stroke", Stroke);
        builder.AddAttribute(7, "stroke-width", StrokeWidth);
        builder.AddAttribute(8, "stroke-linecap", StrokeLinecap);
        builder.AddAttribute(9, "stroke-linejoin", StrokeLinejoin);

        if (Attributes?.Any() is true)
        {
            builder.AddMultipleAttributes(10, Attributes);
        }

        builder.AddMarkupContent(11, icon.Value);
        builder.CloseElement();
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentNullException(nameof(Name));

        if (!string.IsNullOrWhiteSpace(Css))
        {
            Attributes["class"] = Css;
        }
    }

    [Parameter]
    public string Name { get; set; } = "";

    [Parameter]
    public string Css { get; set; } = "";

    [Parameter]
    public string Width { get; set; } = "24";

    [Parameter]
    public string Height { get; set; } = "24";

    [Parameter]
    public string ViewBox { get; set; } = "0 0 24 24";

    [Parameter]
    public string Fill { get; set; } = "none";

    [Parameter]
    public string Stroke { get; set; } = "currentColor";

    [Parameter]
    public string StrokeWidth { get; set; } = "2";

    [Parameter]
    public string StrokeLinecap { get; set; } = "round";

    [Parameter]
    public string StrokeLinejoin { get; set; } = "round";

    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
}