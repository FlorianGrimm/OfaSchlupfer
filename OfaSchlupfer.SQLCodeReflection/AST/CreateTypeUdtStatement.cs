namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CreateTypeUdtStatement : CreateTypeStatement {
        private AssemblyName _assemblyName;

        public AssemblyName AssemblyName {
            get {
                return this._assemblyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._assemblyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.AssemblyName?.Accept(visitor);
        }
    }
}
