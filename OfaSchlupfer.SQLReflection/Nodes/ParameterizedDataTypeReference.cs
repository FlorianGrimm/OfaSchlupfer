namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.Collections.Generic;

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
