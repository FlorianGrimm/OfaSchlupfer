#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class WithCtesAndXmlNamespaces : SqlNode {
        public WithCtesAndXmlNamespaces() : base() { }
        public WithCtesAndXmlNamespaces(ScriptDom.WithCtesAndXmlNamespaces src) : base(src) {
            this.XmlNamespaces = Copier.Copy<XmlNamespaces>(src.XmlNamespaces);
            Copier.CopyList(this.CommonTableExpressions, src.CommonTableExpressions);
            this.ChangeTrackingContext = Copier.Copy<ValueExpression>(src.ChangeTrackingContext);
        }
        public XmlNamespaces XmlNamespaces;
        public List<CommonTableExpression> CommonTableExpressions { get; } = new List<CommonTableExpression>();
        public ValueExpression ChangeTrackingContext;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.XmlNamespaces?.Accept(visitor);
            this.CommonTableExpressions.Accept(visitor);
            this.ChangeTrackingContext?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
