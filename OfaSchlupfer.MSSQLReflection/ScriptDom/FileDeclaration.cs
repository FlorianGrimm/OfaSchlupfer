using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FileDeclaration : TSqlFragment {
        private List<FileDeclarationOption> _options = new List<FileDeclarationOption>();

        private bool _isPrimary;

        public List<FileDeclarationOption> Options {
            get {
                return this._options;
            }
        }

        public bool IsPrimary {
            get {
                return this._isPrimary;
            }

            set {
                this._isPrimary = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
