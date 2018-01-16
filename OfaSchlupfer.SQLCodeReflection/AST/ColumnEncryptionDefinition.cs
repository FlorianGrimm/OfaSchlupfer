namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class ColumnEncryptionDefinition : TSqlFragment {
        public List<ColumnEncryptionDefinitionParameter> Parameters { get; } = new List<ColumnEncryptionDefinitionParameter>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
