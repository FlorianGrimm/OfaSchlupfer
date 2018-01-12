using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BoundingBoxSpatialIndexOption : SpatialIndexOption {
        private List<BoundingBoxParameter> _boundingBoxParameters = new List<BoundingBoxParameter>();

        public List<BoundingBoxParameter> BoundingBoxParameters {
            get {
                return this._boundingBoxParameters;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.BoundingBoxParameters.Count; i < count; i++) {
                this.BoundingBoxParameters[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
