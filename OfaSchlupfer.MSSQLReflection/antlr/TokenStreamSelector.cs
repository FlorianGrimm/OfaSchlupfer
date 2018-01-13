#pragma warning disable SA1100
#pragma warning disable SA1300 // Element must begin with upper-case letter
#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1600 // Elements must be documented
namespace antlr {
    using System;
    using System.Collections;

    internal class TokenStreamSelector : TokenStream {
        protected internal Hashtable inputStreamNames;

        protected internal TokenStream input;

        protected internal Stack streamStack = new Stack();

        public TokenStreamSelector() {
            this.inputStreamNames = new Hashtable();
        }

        public virtual void addInputStream(TokenStream stream, string key) {
            this.inputStreamNames[key] = stream;
        }

        public virtual TokenStream getCurrentStream() {
            return this.input;
        }

        public virtual TokenStream getStream(string sname) {
            TokenStream tokenStream = (TokenStream)this.inputStreamNames[sname];
            if (tokenStream == null) {
                throw new ArgumentException("TokenStream " + sname + " not found");
            }
            return tokenStream;
        }

        public virtual IToken nextToken() {
            while (true) {
                try {
                    return this.input.nextToken();
                } catch (TokenStreamRetryException) {
                }
            }
        }

        public virtual TokenStream pop() {
            TokenStream tokenStream = (TokenStream)this.streamStack.Pop();
            this.select(tokenStream);
            return tokenStream;
        }

        public virtual void push(TokenStream stream) {
            this.streamStack.Push(this.input);
            this.select(stream);
        }

        public virtual void push(string sname) {
            this.streamStack.Push(this.input);
            this.select(sname);
        }

        public virtual void retry() {
            throw new TokenStreamRetryException();
        }

        public virtual void select(TokenStream stream) {
            this.input = stream;
        }

        public virtual void select(string sname) {
            this.input = this.getStream(sname);
        }
    }
}
