using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterSchemaStatement : TSqlStatement {
        private Identifier _name;

        private SchemaObjectName _objectName;

        private SecurityObjectKind _objectKind;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName ObjectName {
            get {
                return this._objectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._objectName = value;
            }
        }

        public SecurityObjectKind ObjectKind {
            get {
                return this._objectKind;
            }

            set {
                this._objectKind = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ObjectName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
