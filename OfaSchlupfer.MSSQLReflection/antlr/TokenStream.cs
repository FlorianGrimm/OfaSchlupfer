#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1302 // Interface names must begin with I
namespace antlr {
    internal interface TokenStream {
        IToken nextToken();
    }
}
