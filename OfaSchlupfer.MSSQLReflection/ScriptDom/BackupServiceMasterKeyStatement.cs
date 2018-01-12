using System;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class BackupServiceMasterKeyStatement : BackupRestoreMasterKeyStatementBase {
        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
