namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class Literal : ValueExpression {
        private string _value;

        public abstract LiteralType LiteralType {
            get;
        }

        public string Value {
            get {
                return this._value;
            }

            set {
                this._value = value;
            }
        }
    }
}
