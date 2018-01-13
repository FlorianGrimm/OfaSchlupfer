#pragma warning disable SA1600 // Elements must be documented
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1602 // Enumeration items must be documented

namespace antlr {
    internal class CommonHiddenStreamToken : CommonToken, IHiddenStreamToken, IToken {
        internal class CommonHiddenStreamTokenCreator : TokenCreator {
            public override string TokenTypeName {
                get {
                    return typeof(CommonHiddenStreamToken).FullName;
                }
            }

            public override IToken Create() {
                return new CommonHiddenStreamToken();
            }
        }

        public static new readonly CommonHiddenStreamTokenCreator Creator = new CommonHiddenStreamTokenCreator();

        protected internal IHiddenStreamToken hiddenBefore;

        protected internal IHiddenStreamToken hiddenAfter;

        public CommonHiddenStreamToken() {
        }

        public CommonHiddenStreamToken(int t, string txt)
            : base(t, txt) {
        }

        public CommonHiddenStreamToken(string s)
            : base(s) {
        }

        public virtual IHiddenStreamToken getHiddenAfter() {
            return this.hiddenAfter;
        }

        public virtual IHiddenStreamToken getHiddenBefore() {
            return this.hiddenBefore;
        }

        public virtual void setHiddenAfter(IHiddenStreamToken t) {
            this.hiddenAfter = t;
        }

        public virtual void setHiddenBefore(IHiddenStreamToken t) {
            this.hiddenBefore = t;
        }
    }
}
