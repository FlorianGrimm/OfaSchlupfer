#pragma warning disable SA1100,SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

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
            get => this.Identifiers[index];
            set => this.Identifiers[index] = value;
        }
        public int Count => this.Identifiers.Count;
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
        public virtual Identifier ServerIdentifier => this.ChooseIdentifier(ServerModifier);
        public virtual Identifier DatabaseIdentifier => this.ChooseIdentifier(DatabaseModifier);
        public virtual Identifier SchemaIdentifier => this.ChooseIdentifier(SchemaModifier);
        public virtual Identifier BaseIdentifier => this.ChooseIdentifier(BaseModifier);
        protected Identifier ChooseIdentifier(int modifier) {
            int num = this.Identifiers.Count - modifier;
            if (num < 0) {
                return null;
            } else {
                return this.Identifiers[num];
            }
        }
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public class ChildObjectName : SchemaObjectName {
        private const int ServerModifierNumber = 5;
        private const int DatabaseModifierNumber = 4;
        private const int SchemaModifierNumber = 3;
        private const int BaseModifierNumber = 2;
        private const int ChildModifierNumber = 1;
        public ChildObjectName() : base() { }
        public ChildObjectName(ScriptDom.ChildObjectName src) : base(src) { }
        public override Identifier ServerIdentifier => base.ChooseIdentifier(SchemaModifierNumber);
        public override Identifier DatabaseIdentifier => base.ChooseIdentifier(DatabaseModifierNumber);
        public override Identifier SchemaIdentifier => base.ChooseIdentifier(SchemaModifierNumber);
        public override Identifier BaseIdentifier => base.ChooseIdentifier(BaseModifierNumber);
        public virtual Identifier ChildIdentifier => base.ChooseIdentifier(ChildModifierNumber);
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
