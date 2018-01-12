using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public abstract class CursorStatement : TSqlStatement {
        private CursorId _cursor;

        public CursorId Cursor {
            get {
                return this._cursor;
            }

            set {
                this.UpdateTokenInfo(value);
                this._cursor = value;
            }
        }

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            this.Cursor?.Accept(visitor);
            base.AcceptChildren(visitor);
        }
    }
}
