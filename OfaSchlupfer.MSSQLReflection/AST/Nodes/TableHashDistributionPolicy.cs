#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    [System.Diagnostics.DebuggerNonUserCode]
    public sealed class TableHashDistributionPolicy : TableDistributionPolicy {
        public TableHashDistributionPolicy() : base() { }
        public TableHashDistributionPolicy(ScriptDom.TableHashDistributionPolicy src)
            : base(src) {
            this.DistributionColumn = Copier.Copy<Identifier>(src.DistributionColumn);
        }
        public Identifier DistributionColumn;
        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
