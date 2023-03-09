using System.Runtime.CompilerServices;

namespace Lucide.Blazor.Generation.UnitTests;
internal static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Init() => VerifySourceGenerators.Initialize();
}
