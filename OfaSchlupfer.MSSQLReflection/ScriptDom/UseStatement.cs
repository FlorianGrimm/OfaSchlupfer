using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UseStatement : TSqlStatement {
        private Identifier _databaseName;

        public Identifier DatabaseName {
            get {
                return this._databaseName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._databaseName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.DatabaseName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
