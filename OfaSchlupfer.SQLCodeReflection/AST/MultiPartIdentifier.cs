namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public class MultiPartIdentifier : TSqlFragment {
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

        public List<Identifier> Identifiers { get; } = new List<Identifier>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Identifiers.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
