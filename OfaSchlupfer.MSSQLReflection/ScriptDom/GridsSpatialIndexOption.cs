using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class GridsSpatialIndexOption : SpatialIndexOption {
        private List<GridParameter> _gridParameters = new List<GridParameter>();

        public List<GridParameter> GridParameters {
            get {
                return this._gridParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.GridParameters.Count; i < count; i++) {
                this.GridParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
