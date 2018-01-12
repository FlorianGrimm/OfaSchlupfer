using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class NameFileDeclarationOption : FileDeclarationOption {
        private IdentifierOrValueExpression _logicalFileName;

        private bool _isNewName;

        public IdentifierOrValueExpression LogicalFileName {
            get {
                return this._logicalFileName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._logicalFileName = value;
            }
        }

        public bool IsNewName {
            get {
                return this._isNewName;
            }
            set {
                this._isNewName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.LogicalFileName?.Accept(visitor);
        }
    }
}
