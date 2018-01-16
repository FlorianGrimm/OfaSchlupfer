namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class MergeSpecification : DataModificationSpecification {
        private Identifier _tableAlias;

        private TableReference _tableReference;

        private BooleanExpression _searchCondition;

        public Identifier TableAlias {
            get {
                return this._tableAlias;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableAlias = value;
            }
        }

        public TableReference TableReference {
            get {
                return this._tableReference;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableReference = value;
            }
        }

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public List<MergeActionClause> ActionClauses { get; } = new List<MergeActionClause>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableAlias?.Accept(visitor);
            this.TableReference?.Accept(visitor);
            this.SearchCondition?.Accept(visitor);
            this.ActionClauses.Accept(visitor);
        }
    }
}
