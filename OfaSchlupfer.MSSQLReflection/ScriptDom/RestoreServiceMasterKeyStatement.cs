using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class RestoreServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        private bool _isForce;

        public bool IsForce {
            get {
                return this._isForce;
            }
            set {
                this._isForce = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
