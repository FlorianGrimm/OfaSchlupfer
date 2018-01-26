#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public sealed class TableValuedFunctionReturnType : FunctionReturnType {
        public TableValuedFunctionReturnType() : base() { }
        public TableValuedFunctionReturnType(ScriptDom.TableValuedFunctionReturnType src) : base(src) {
            this.DeclareTableVariableBody = Copier.Copy<DeclareTableVariableBody>(src.DeclareTableVariableBody);
        }

        public DeclareTableVariableBody DeclareTableVariableBody { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.DeclareTableVariableBody?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
