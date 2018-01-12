using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterMasterKeyStatement : MasterKeyStatement {
        private AlterMasterKeyOption _option;

        public AlterMasterKeyOption Option {
            get {
                return this._option;
            }
            set {
                this._option = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
