namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class CreateAssemblyStatement : AssemblyStatement, IAuthorization {
        private Identifier _owner;

        public Identifier Owner {
            get {
                return this._owner;
            }
            set {
                base.UpdateTokenInfo(value);
                this._owner = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (base.Name != null) {
                base.Name.Accept(visitor);
            }
            for (int i=0, count = base.Parameters.Count; i < count; i++) {
                base.Parameters[i].Accept(visitor);
            }
            int j = 0;
            for (int count2 = base.Options.Count; j < count2; j++) {
                base.Options[j].Accept(visitor);
            }
            this.Owner?.Accept(visitor);
        }
    }
}
