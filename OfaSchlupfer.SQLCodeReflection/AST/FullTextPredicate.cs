namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class FullTextPredicate : BooleanExpression {
        private FullTextFunctionType _fullTextFunctionType;

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

        public List<ColumnReferenceExpression> Columns { get; } = new List<ColumnReferenceExpression>();

        public ValueExpression Value {
            get {
                return this._value;
            }

            set {
                this.UpdateTokenInfo(value);
                this._value = value;
            }
        }

        public ValueExpression LanguageTerm {
            get {
                return this._languageTerm;
            }

            set {
                this.UpdateTokenInfo(value);
                this._languageTerm = value;
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
            this.Columns.Accept(visitor);
            this.Value?.Accept(visitor);
            this.LanguageTerm?.Accept(visitor);
            this.PropertyName?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
