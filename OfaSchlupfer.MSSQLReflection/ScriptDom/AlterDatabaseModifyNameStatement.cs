using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseModifyNameStatement : AlterDatabaseStatement {
        private Identifier _newDatabaseName;

        public Identifier NewDatabaseName {
            get {
                return this._newDatabaseName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._newDatabaseName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.NewDatabaseName?.Accept(visitor);
        }
    }
}
