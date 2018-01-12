using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterDatabaseScopedConfigurationSetStatement : AlterDatabaseScopedConfigurationStatement {
        private DatabaseConfigurationSetOption _option;

        public DatabaseConfigurationSetOption Option {
            get {
                return this._option;
            }
            set {
                base.UpdateTokenInfo(value);
                this._option = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Option?.Accept(visitor);
        }
    }
}
