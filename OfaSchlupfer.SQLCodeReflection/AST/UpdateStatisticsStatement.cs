namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class UpdateStatisticsStatement : TSqlStatement {
        private SchemaObjectName _schemaObjectName;

        public SchemaObjectName SchemaObjectName {
            get {
                return this._schemaObjectName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._schemaObjectName = value;
            }
        }

        public List<Identifier> SubElements { get; } = new List<Identifier>();

        public List<StatisticsOption> StatisticsOptions { get; } = new List<StatisticsOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.SchemaObjectName?.Accept(visitor);
            this.SubElements.Accept(visitor);
            this.StatisticsOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
