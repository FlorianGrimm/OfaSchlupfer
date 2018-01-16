namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class CursorDefinition : TSqlFragment {
        private SelectStatement _select;

        public List<CursorOption> Options { get; } = new List<CursorOption>();

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
            this.Options.Accept(visitor);
            this.Select?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
