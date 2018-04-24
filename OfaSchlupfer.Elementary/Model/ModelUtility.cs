namespace OfaSchlupfer.Model {
    using System;

    public sealed class ModelUtility {
        public readonly StringComparer StringComparer;

        public readonly ModelEntityNameEqualityComparer ModelEntityNameEqualityComparer;

        private ModelUtility() {
            this.StringComparer = StringComparer.InvariantCultureIgnoreCase;
            this.ModelEntityNameEqualityComparer = new ModelEntityNameEqualityComparer();
        }

        public static ModelUtility Instance { get { return Nested.instance; } }

        private class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly ModelUtility instance = new ModelUtility();
        }        
    }
}
