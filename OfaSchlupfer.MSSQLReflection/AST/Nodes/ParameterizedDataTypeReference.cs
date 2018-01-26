#pragma warning disable SA1107,SA1127,SA1128,SA1402,SA1516,SA1515,SA1600

namespace OfaSchlupfer.MSSQLReflection.AST {
    using System.Collections.Generic;
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

    [System.Serializable]
    public abstract class ParameterizedDataTypeReference : DataTypeReference {
        public ParameterizedDataTypeReference() : base() { }
        public ParameterizedDataTypeReference(ScriptDom.ParameterizedDataTypeReference src) : base(src) {
            Copier.CopyList(this.Parameters, src.Parameters);
        }
        public List<Literal> Parameters { get; } = new List<Literal>();

        public override void AcceptChildren(SqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.Parameters.Accept(visitor);
        }
    }
}
