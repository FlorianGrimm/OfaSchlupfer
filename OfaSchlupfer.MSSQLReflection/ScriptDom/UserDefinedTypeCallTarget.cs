using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class UserDefinedTypeCallTarget : CallTarget {
        private SchemaObjectName _schemaObjectName;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
