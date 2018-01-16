namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class ApplicationRoleStatement : TSqlStatement {
        private Identifier _name;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public List<ApplicationRoleOption> ApplicationRoleOptions { get; } = new List<ApplicationRoleOption>();

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.ApplicationRoleOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
