namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class PrivilegeSecurityElement80 : SecurityElement80 {
        private SchemaObjectName _schemaObjectName;

        public List<Privilege80> Privileges { get; } = new List<Privilege80>();

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> Columns { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Privileges.Accept(visitor);
            this.SchemaObjectName?.Accept(visitor);
            this.Columns.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
