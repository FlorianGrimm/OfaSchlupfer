using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class InlineResultSetDefinition : ResultSetDefinition {
        private List<ResultColumnDefinition> _resultColumnDefinitions = new List<ResultColumnDefinition>();

        public List<ResultColumnDefinition> ResultColumnDefinitions {
            get {
                return this._resultColumnDefinitions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i = 0, count = this.ResultColumnDefinitions.Count; i < count; i++) {
                this.ResultColumnDefinitions[i].Accept(visitor);
            }
        }
    }
}
