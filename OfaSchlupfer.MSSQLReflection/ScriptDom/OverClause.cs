using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class OverClause : TSqlFragment {
        private List<ScalarExpression> _partitions = new List<ScalarExpression>();

        private OrderByClause _orderByClause;

        private WindowFrameClause _windowFrameClause;

        public List<ScalarExpression> Partitions {
            get {
                return this._partitions;
            }
        }

        public OrderByClause OrderByClause {
            get {
                return this._orderByClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._orderByClause = value;
            }
        }

        public WindowFrameClause WindowFrameClause {
            get {
                return this._windowFrameClause;
            }

            set {
                this.UpdateTokenInfo(value);
                this._windowFrameClause = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Partitions.Count; i < count; i++) {
                this.Partitions[i].Accept(visitor);
            }
            this.OrderByClause?.Accept(visitor);
            this.WindowFrameClause?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
