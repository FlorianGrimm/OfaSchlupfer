using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class CreateTypeStatement : TSqlStatement {
        private SchemaObjectName _name;

        public SchemaObjectName Name {
            get {
                return this._name;
            }
            set {
                base.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
