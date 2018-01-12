using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateSynonymStatement : TSqlStatement {
        private SchemaObjectName _name;

        private SchemaObjectName _forName;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public SchemaObjectName ForName {
            get {
                return this._forName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._forName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ForName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
