namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class VariableReference : ValueExpression {
        private string _name;

        public string Name {
            get {
                return this._name;
            }

            set {
                this._name = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
