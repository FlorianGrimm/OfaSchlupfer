#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented
namespace antlr {
    internal interface IHiddenStreamToken : IToken {
        IHiddenStreamToken getHiddenAfter();

        void setHiddenAfter(IHiddenStreamToken t);

        IHiddenStreamToken getHiddenBefore();

        void setHiddenBefore(IHiddenStreamToken t);
    }
}
