using System.Runtime.CompilerServices;

namespace OfaSchlupfer.TextTemplate.Helpers {
    /// <summary>
    /// Internal helper to allow to declare a method using AggressiveInlining without being .NET 4.0+
    /// </summary>
    internal static class MethodImplOptionsPortable {
        public const MethodImplOptions AggressiveInlining = (MethodImplOptions)256;
    }
}