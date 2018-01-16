namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FullTextTableReference : TableReferenceWithAlias {
        private FullTextFunctionType _fullTextFunctionType;

        private SchemaObjectName _tableName;

        private ValueExpression _searchCondition;

        private ValueExpression _topN;

        private ValueExpression _language;

        private StringLiteral _propertyName;

        public FullTextFunctionType FullTextFunctionType {
            get {
                return this._fullTextFunctionType;
            }

            set {
                this._fullTextFunctionType = value;
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

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public ValueExpression SearchCondition {
            get {
                return this._searchCondition;
            }

            set {
                this.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public ValueExpression TopN {
            get {
                return this._topN;
            }

            set {
                this.UpdateTokenInfo(value);
                this._topN = value;
            }
        }

        public ValueExpression Language {
            get {
                return this._language;
            }

            set {
                this.UpdateTokenInfo(value);
                this._language = value;
            }
        }

        public StringLiteral PropertyName {
            get {
                return this._propertyName;
            }

            set {
                this.UpdateTokenInfo(value);
                this._propertyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableName?.Accept(visitor);
            this.Columns.Accept(visitor);
            this.SearchCondition?.Accept(visitor);
            this.TopN?.Accept(visitor);
            this.Language?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
        }
    }
}
