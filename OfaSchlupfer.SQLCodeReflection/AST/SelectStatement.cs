namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public class SelectStatement : StatementWithCtesAndXmlNamespaces {
        private QueryExpression _queryExpression;

        private SchemaObjectName _into;

        private Identifier _on;

        public QueryExpression QueryExpression {
            get {
                return this._queryExpression;
            }

            set {
                this.UpdateTokenInfo(value);
                this._queryExpression = value;
            }
        }

        public SchemaObjectName Into {
            get {
                return this._into;
            }

            set {
                this.UpdateTokenInfo(value);
                this._into = value;
            }
        }

        public Identifier On {
            get {
                return this._on;
            }

            set {
                this.UpdateTokenInfo(value);
                this._on = value;
            }
        }

        public List<ComputeClause> ComputeClauses { get; } = new List<ComputeClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.QueryExpression?.Accept(visitor);
            this.Into?.Accept(visitor);
            this.On?.Accept(visitor);
            var computeClauses = this.ComputeClauses;
            for (int i = 0, count = computeClauses.Count; i < count; i++) {
                computeClauses[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
