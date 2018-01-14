#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter

namespace antlr {
    internal abstract class TokenCreator {
        public abstract string TokenTypeName {
            get;
        }

        public abstract IToken Create();
    }
}
