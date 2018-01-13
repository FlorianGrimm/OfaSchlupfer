namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class AlterLoginEnableDisableStatement : AlterLoginStatement {
        private bool _isEnable;

        public bool IsEnable {
            get {
                return this._isEnable;
            }

            set {
                this._isEnable = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
