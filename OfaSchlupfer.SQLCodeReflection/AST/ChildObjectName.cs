#pragma warning disable SA1100 // Do not prefix calls with base unless local implementation exists
#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.AST {
    [System.Serializable]
    //public class ChildObjectName : SchemaObjectName {
    public sealed class ChildObjectName : MultiPartIdentifier {
        public Identifier ChildIdentifier => this.ChooseIdentifier(1);

        public Identifier BaseIdentifier => this.ChooseIdentifier(2);

        public Identifier SchemaIdentifier => this.ChooseIdentifier(3);

        public Identifier DatabaseIdentifier => this.ChooseIdentifier(4);

        public Identifier ServerIdentifier => this.ChooseIdentifier(5);

        private Identifier ChooseIdentifier(int modifier) {
            int num = this.Identifiers.Count - modifier;
            if (num < 0) {
                return null;
            } else {
                return this.Identifiers[num];
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
