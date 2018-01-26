#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public class DeclareVariableElement : SqlNode {
        public DeclareVariableElement() : base() { }
        public DeclareVariableElement(ScriptDom.DeclareVariableElement src) : base(src) {
            this.VariableName = Copier.Copy<Identifier>(src.VariableName);
            this.DataType = Copier.Copy<DataTypeReference>(src.DataType);
            this.Nullable = Copier.Copy<NullableConstraintDefinition>(src.Nullable);
            this.Value = Copier.Copy<ScalarExpression>(src.Value);
        }

        public Identifier VariableName { get; set; }

        public DataTypeReference DataType { get; set; }

        public NullableConstraintDefinition Nullable { get; set; }

        public ScalarExpression Value { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            this.VariableName?.Accept(visitor);
            this.DataType?.Accept(visitor);
            this.Nullable?.Accept(visitor);
            this.Value?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
