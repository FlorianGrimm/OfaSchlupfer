#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class MultiPartIdentifier : SqlNode {
        public MultiPartIdentifier() : base() { }
        public MultiPartIdentifier(ScriptDom.MultiPartIdentifier src) : base(src) {
            Copier.CopyList(this.Identifiers, src.Identifiers);
        }
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
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.Identifiers.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class SchemaObjectName : MultiPartIdentifier {
        private const int MaxIdentifiers = 5;

        private const int ServerModifier = 4;

        private const int DatabaseModifier = 3;

        private const int SchemaModifier = 2;

        private const int BaseModifier = 1;
        public SchemaObjectName() : base() { }
        public SchemaObjectName(ScriptDom.SchemaObjectName src) : base(src) { }
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
            int num = this.Identifiers.Count - modifier;
            if (num < 0) {
                return null;
            }
            return this.Identifiers[num];
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
