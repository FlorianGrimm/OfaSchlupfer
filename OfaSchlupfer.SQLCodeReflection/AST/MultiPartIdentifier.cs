namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public class MultiPartIdentifier : TSqlFragment {
        private List<Identifier> _identifiers = new List<Identifier>();

        public Identifier this[int index] {
            get {
                return this.Identifiers[index];
            }

            set {
                this.Identifiers[index] = value;
            }
        }

        public int Count {
            get {
                return this.Identifiers.Count;
            }
        }

        public List<Identifier> Identifiers {
            get {
                return this._identifiers;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Identifiers.Count; i < count; i++) {
                this.Identifiers[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
