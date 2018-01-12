using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FullTextTableReference : TableReferenceWithAlias {
        private FullTextFunctionType _fullTextFunctionType;

        private SchemaObjectName _tableName;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

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
                base.UpdateTokenInfo(value);
                this._tableName = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public ValueExpression SearchCondition {
            get {
                return this._searchCondition;
            }
            set {
                base.UpdateTokenInfo(value);
                this._searchCondition = value;
            }
        }

        public ValueExpression TopN {
            get {
                return this._topN;
            }
            set {
                base.UpdateTokenInfo(value);
                this._topN = value;
            }
        }

        public ValueExpression Language {
            get {
                return this._language;
            }
            set {
                base.UpdateTokenInfo(value);
                this._language = value;
            }
        }

        public StringLiteral PropertyName {
            get {
                return this._propertyName;
            }
            set {
                base.UpdateTokenInfo(value);
                this._propertyName = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            this.TableName?.Accept(visitor);
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.SearchCondition?.Accept(visitor);
            this.TopN?.Accept(visitor);
            this.Language?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
        }
    }
}
