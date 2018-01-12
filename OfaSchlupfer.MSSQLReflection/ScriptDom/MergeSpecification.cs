using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MergeSpecification : DataModificationSpecification {
        private Identifier _tableAlias;

        private TableReference _tableReference;

        private BooleanExpression _searchCondition;

        private List<MergeActionClause> _actionClauses = new List<MergeActionClause>();

        public Identifier TableAlias {
            get {
                return this._tableAlias;
            }
            set {
                base.UpdateTokenInfo(value);
                this._tableAlias = value;
            }
        }

        public TableReference TableReference {
            get {
                return this._tableReference;
            }
            set {
                base.UpdateTokenInfo(value);
                this._tableReference = value;
            }
        }

        public BooleanExpression SearchCondition {
            get {
                return this._searchCondition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public List<MergeActionClause> ActionClauses {
            get {
                return this._actionClauses;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableAlias?.Accept(visitor);
            this.TableReference?.Accept(visitor);
            this.SearchCondition?.Accept(visitor);
            for (int i=0, count = this.ActionClauses.Count; i < count; i++) {
                this.ActionClauses[i].Accept(visitor);
            }
        }
    }
}
