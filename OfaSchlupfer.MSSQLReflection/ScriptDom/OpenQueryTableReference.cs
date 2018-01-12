using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OpenQueryTableReference : TableReferenceWithAlias {
        private Identifier _linkedServer;

        private StringLiteral _query;

        public Identifier LinkedServer {
            get {
                return this._linkedServer;
            }
            set {
                base.UpdateTokenInfo(value);
                this._linkedServer = value;
            }
        }

        public StringLiteral Query {
            get {
                return this._query;
            }
            set {
                base.UpdateTokenInfo(value);
                this._query = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LinkedServer?.Accept(visitor);
            this.Query?.Accept(visitor);
        }
    }
}
