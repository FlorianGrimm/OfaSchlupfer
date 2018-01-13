namespace OfaSchlupfer.ScriptDom {

    using System.Collections.Generic;
    [System.Serializable]
    public sealed class WindowsCreateLoginSource : CreateLoginSource {
        private List<PrincipalOption> _options = new List<PrincipalOption>();

        public List<PrincipalOption> Options {
            get {
                return this._options;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i = 0, count = this.Options.Count; i < count; i++) {
                this.Options[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
