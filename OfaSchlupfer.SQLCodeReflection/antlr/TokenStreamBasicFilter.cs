#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1600 // Elements must be documented

namespace antlr {
    using antlr.collections.impl;

    internal class TokenStreamBasicFilter : TokenStream {
        protected internal BitSet discardMask;

        protected internal TokenStream input;

        public TokenStreamBasicFilter(TokenStream input) {
            this.input = input;
            this.discardMask = new BitSet();
        }

        public virtual void discard(int ttype) {
            this.discardMask.add(ttype);
        }

        public virtual void discard(BitSet mask) {
            this.discardMask = mask;
        }

        public virtual IToken nextToken() {
            IToken token = this.input.nextToken();
            while (token != null && this.discardMask.member(token.Type)) {
                token = this.input.nextToken();
            }
            return token;
        }
    }
}
