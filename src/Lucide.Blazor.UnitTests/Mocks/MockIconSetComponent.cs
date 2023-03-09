using Lucide.Blazor.Components;
using Lucide.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Lucide.Blazor.UnitTests.Utilities;
internal sealed class MockIconSetComponent : ComponentBase
{
    /// <summary>
    /// Generates a grid component of icons with their associated name, using the following template:
    /// 
    /// <!doctype html>
    /// <html>
    /// <head>
    ///   <meta charset="UTF-8">
    ///   <meta name="viewport" content="width=device-width, initial-scale=1.0">
    ///   <script src="https://cdn.tailwindcss.com"></script>
    /// </head>
    ///   <body>
    ///     <div class="grid grid-cols-12">
    ///       <div class="flex flex-col items-center justify-center p-2 text-center">
    ///         <svg></svg>
    ///         <span class="text-xs"></span>
    ///       </div>
    ///     </div>
    ///   </body>
    /// </html>
    /// </summary>
    /// <param name="builder"></param>
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        base.BuildRenderTree(builder);

        var names = IconSet.Icons.Select(kvp => kvp.Key);

        builder.AddMarkupContent(0,
            """
            <!doctype html>
            <html>
            <head>
              <meta charset="UTF-8">
              <meta name="viewport" content="width=device-width, initial-scale=1.0">
              <script src="https://cdn.tailwindcss.com"></script>
            </head>
              <body>
                <div class="grid grid-cols-12">


            """);

        foreach (var name in names)
        {
            builder.AddMarkupContent(1,
                """
                      <div class="flex flex-col items-center justify-center p-2 text-center">

                """);

            builder.OpenComponent(2, typeof(Icon));
            builder.AddAttribute(3, nameof(Icon.Name), name);
            builder.CloseComponent();

            builder.AddMarkupContent(4,
                $$"""

                        <span class="text-xs">{{name}}</span>
                      </div>

                """);
        }

        builder.AddMarkupContent(5, 
                """
                    </div>
                  </body>
                </html>
                """);
    }
}
