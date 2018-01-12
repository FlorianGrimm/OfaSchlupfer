using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class FullTextPredicate : BooleanExpression {
        private FullTextFunctionType _fullTextFunctionType;

        private List<ColumnReferenceExpression> _columns = new List<ColumnReferenceExpression>();

        private ValueExpression _value;

        private ValueExpression _languageTerm;

        private StringLiteral _propertyName;

        public FullTextFunctionType FullTextFunctionType {
            get {
                return this._fullTextFunctionType;
            }
            set {
                this._fullTextFunctionType = value;
            }
        }

        public List<ColumnReferenceExpression> Columns {
            get {
                return this._columns;
            }
        }

        public ValueExpression Value {
            get {
                return this._value;
            }
            set {
                base.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public ValueExpression LanguageTerm {
            get {
                return this._languageTerm;
            }
            set {
                base.UpdateTokenInfo(value);
                this._languageTerm = value;
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
            for (int i=0, count = this.Columns.Count; i < count; i++) {
                this.Columns[i].Accept(visitor);
            }
            this.Value?.Accept(visitor);
            this.LanguageTerm?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
