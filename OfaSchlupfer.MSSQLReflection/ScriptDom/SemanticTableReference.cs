using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class SemanticTableReference : TableReferenceWithAlias {
        private SemanticFunctionType _semanticFunctionType;

        private SchemaObjectName _tableName;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        private ScalarExpression _sourceKey;

        private ColumnReferenceExpression _matchedColumn;

        private ScalarExpression _matchedKey;

        public SemanticFunctionType SemanticFunctionType {
            get {
                return this._semanticFunctionType;
            }

            set {
                this._semanticFunctionType = value;
            }
        }

        public SchemaObjectName TableName {
            get {
                return this._tableName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public ScalarExpression SourceKey {
            get {
                return this._sourceKey;
            }

            set {
                this.UpdateTokenInfo(value);
                this._sourceKey = value;
            }
        }

        public ColumnReferenceExpression MatchedColumn {
            get {
                return this._matchedColumn;
            }

            set {
                this.UpdateTokenInfo(value);
                this._matchedColumn = value;
            }
        }

        public ScalarExpression MatchedKey {
            get {
                return this._matchedKey;
            }

            set {
                this.UpdateTokenInfo(value);
                this._matchedKey = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableName?.Accept(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.SourceKey?.Accept(visitor);
            this.MatchedColumn?.Accept(visitor);
            this.MatchedKey?.Accept(visitor);
        }
    }
}
