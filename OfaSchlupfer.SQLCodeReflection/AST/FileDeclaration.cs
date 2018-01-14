using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class FileDeclaration : TSqlFragment {
        private List<FileDeclarationOption> _options = new List<FileDeclarationOption>();

        public List<FileDeclarationOption> Options {
            get {
                return this._options;
            }
        }

        public bool IsPrimary { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
