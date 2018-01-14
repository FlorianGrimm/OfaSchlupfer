using System.Collections.Generic;

namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class CursorDefinition : TSqlFragment {
        private List<CursorOption> _options = new List<CursorOption>();

        private SelectStatement _select;

        public List<CursorOption> Options {
            get {
                return this._options;
            }
        }

        public SelectStatement Select {
            get {
                return this._select;
            }

            set {
                this.UpdateTokenInfo(value);
                this._select = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
