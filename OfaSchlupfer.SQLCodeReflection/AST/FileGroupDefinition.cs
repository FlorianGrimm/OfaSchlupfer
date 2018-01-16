namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FileGroupDefinition : TSqlFragment {
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

        public List<FileDeclaration> FileDeclarations { get; } = new List<FileDeclaration>();

        public bool IsDefault { get; set; }

        public bool ContainsFileStream { get; set; }

        public bool ContainsMemoryOptimizedData { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.FileDeclarations.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
