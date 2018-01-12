using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterPartitionSchemeStatement : TSqlStatement {
        private Identifier _name;

        private IdentifierOrValueExpression _fileGroup;

        public Identifier Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public IdentifierOrValueExpression FileGroup {
            get {
                return this._fileGroup;
            }
            set {
                base.UpdateTokenInfo(value);
                this._fileGroup = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.FileGroup?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
