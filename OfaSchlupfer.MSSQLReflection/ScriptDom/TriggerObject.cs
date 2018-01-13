namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class TriggerObject : TSqlFragment {
        private SchemaObjectName _name;

        private TriggerScope _triggerScope;

        public SchemaObjectName Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public TriggerScope TriggerScope {
            get {
                return this._triggerScope;
            }

            set {
                this._triggerScope = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
