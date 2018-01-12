using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ChangeTableChangesTableReference : TableReferenceWithAliasAndColumns {
        private SchemaObjectName _target;

        private ValueExpression _sinceVersion;

        public SchemaObjectName Target {
            get {
                return this._target;
            }

            set {
                this.UpdateTokenInfo(value);
                this._target = value;
            }
        }

        public ValueExpression SinceVersion {
            get {
                return this._sinceVersion;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sinceVersion = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Target?.Accept(visitor);
            this.SinceVersion?.Accept(visitor);
        }
    }
}
