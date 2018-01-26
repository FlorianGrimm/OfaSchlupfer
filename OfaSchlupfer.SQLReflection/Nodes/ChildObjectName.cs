#pragma warning disable SA1100 // Do not prefix calls with base unless local implementation exists
#pragma warning disable SA1600 // Elements must be documented

namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class ChildObjectName : SchemaObjectName {
        private const int ServerModifierNumber = 5;

        private const int DatabaseModifierNumber = 4;

        private const int SchemaModifierNumber = 3;

        private const int BaseModifierNumber = 2;

        private const int ChildModifierNumber = 1;

        public ChildObjectName() : base() { }
        public ChildObjectName(ScriptDom.ChildObjectName src) : base(src) {
        }

        public override Identifier BaseIdentifier {
            get {
                return base.ChooseIdentifier(2);
            }
        }

        public override Identifier DatabaseIdentifier {
            get {
                return base.ChooseIdentifier(4);
            }
        }

        public override Identifier SchemaIdentifier {
            get {
                return base.ChooseIdentifier(3);
            }
        }

        public override Identifier ServerIdentifier {
            get {
                return base.ChooseIdentifier(5);
            }
        }

        public virtual Identifier ChildIdentifier {
            get {
                return base.ChooseIdentifier(1);
            }
        }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
