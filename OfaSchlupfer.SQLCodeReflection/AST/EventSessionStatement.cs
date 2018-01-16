namespace OfaSchlupfer.AST {
    using System.Collections.Generic;

    [System.Serializable]
    public abstract class EventSessionStatement : TSqlStatement {
        private Identifier _name;

        private EventSessionScope _sessionScope;

        public Identifier Name {
            get {
                return this._name;
            }

            set {
                this.UpdateTokenInfo(value);
                this._name = value;
            }
        }

        public EventSessionScope SessionScope {
            get {
                return this._sessionScope;
            }

            set {
                this._sessionScope = value;
            }
        }

        public List<EventDeclaration> EventDeclarations { get; } = new List<EventDeclaration>();

        public List<TargetDeclaration> TargetDeclarations { get; } = new List<TargetDeclaration>();

        public List<SessionOption> SessionOptions { get; } = new List<SessionOption>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Name?.Accept(visitor);
            this.EventDeclarations.Accept(visitor);
            this.TargetDeclarations.Accept(visitor);
            this.SessionOptions.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
