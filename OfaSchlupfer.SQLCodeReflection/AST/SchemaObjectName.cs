namespace OfaSchlupfer.AST {
    [System.Serializable]
    public class SchemaObjectName : MultiPartIdentifier {
        private const int MaxIdentifiers = 5;

        private const int ServerModifier = 4;

        private const int DatabaseModifier = 3;

        private const int SchemaModifier = 2;

        private const int BaseModifier = 1;

        public virtual Identifier ServerIdentifier {
            get {
                return this.ChooseIdentifier(4);
            }
        }

        public virtual Identifier DatabaseIdentifier {
            get {
                return this.ChooseIdentifier(3);
            }
        }

        public virtual Identifier SchemaIdentifier {
            get {
                return this.ChooseIdentifier(2);
            }
        }

        public virtual Identifier BaseIdentifier {
            get {
                return this.ChooseIdentifier(1);
            }
        }

        protected Identifier ChooseIdentifier(int modifier) {
            int num = base.Identifiers.Count - modifier;
            if (num < 0) {
                return null;
            }
            return base.Identifiers[num];
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
