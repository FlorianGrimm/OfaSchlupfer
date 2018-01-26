using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;

namespace OfaSchlupfer.SQLReflection {
    using ScriptDom = Microsoft.SqlServer.TransactSql.ScriptDom;
    [System.Serializable]
    public abstract class Literal : ValueExpression {
        public Literal() : base() { }
        public Literal(ScriptDom.Literal src) : base(src) {
            this.Value = src.Value;
        }

        public abstract ScriptDom.LiteralType LiteralType { get; }

        public string Value { get; set; }
    }

    [System.Serializable]
    public sealed class NullLiteral : Literal {
        public NullLiteral() : base() { }
        public NullLiteral(ScriptDom.NullLiteral src) : base(src) { }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Null;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class DefaultLiteral : Literal {
        public DefaultLiteral() : base() { }
        public DefaultLiteral(ScriptDom.DefaultLiteral src) : base(src) { }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Default;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }


    [System.Serializable]
    public sealed class IdentifierLiteral : Literal {
        private ScriptDom.QuoteType _quoteType;

        public IdentifierLiteral() : base() { }
        public IdentifierLiteral(ScriptDom.IdentifierLiteral src) : base(src) {
            this._quoteType = src.QuoteType;
        }

        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Identifier;

        public ScriptDom.QuoteType QuoteType {
            get {
                return this._quoteType;
            }

            set {
                this._quoteType = value;
            }
        }

        internal void SetUnquotedIdentifier(string text) {
            base.Value = text;
            this._quoteType = ScriptDom.QuoteType.NotQuoted;
        }

        internal void SetIdentifier(string text) {
            base.Value = Identifier.DecodeIdentifier(text, out this._quoteType);
        }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class StringLiteral : Literal {
        public StringLiteral() : base() { }
        public StringLiteral(ScriptDom.StringLiteral src) : base(src) {
            this.IsNational = src.IsNational;
            this.IsLargeObject = src.IsLargeObject;
        }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.String;

        public bool IsNational { get; set; }

        public bool IsLargeObject { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
    [System.Serializable]
    public sealed class MaxLiteral : Literal {
        public MaxLiteral() : base() { }
        public MaxLiteral(ScriptDom.MaxLiteral src) : base(src) { }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Max;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class MoneyLiteral : Literal {
        public MoneyLiteral() : base() { }
        public MoneyLiteral(ScriptDom.MoneyLiteral src) : base(src) { }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Money;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
    [System.Serializable]
    public sealed class RealLiteral : Literal {
        public RealLiteral() : base() { }
        public RealLiteral(ScriptDom.RealLiteral src) : base(src) {
        }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Real;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class BinaryLiteral : Literal {
        public BinaryLiteral() : base() { }
        public BinaryLiteral(ScriptDom.BinaryLiteral src) : base(src) {
            this.IsLargeObject = src.IsLargeObject;
        }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Binary;

        public bool IsLargeObject { get; set; }

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class NumericLiteral : Literal {
        public NumericLiteral() : base() { }
        public NumericLiteral(ScriptDom.NumericLiteral src) : base(src) {
        }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Numeric;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

    [System.Serializable]
    public sealed class IntegerLiteral : Literal {
        public IntegerLiteral() : base() { }
        public IntegerLiteral(ScriptDom.IntegerLiteral src) : base(src) { }
        public override ScriptDom.LiteralType LiteralType => ScriptDom.LiteralType.Integer;

        public override void Accept(SqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }

}
