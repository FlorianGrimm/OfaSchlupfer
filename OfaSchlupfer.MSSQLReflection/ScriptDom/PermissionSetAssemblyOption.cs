namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class PermissionSetAssemblyOption : AssemblyOption {
        private PermissionSetOption _permissionSetOption;

        public PermissionSetOption PermissionSetOption {
            get {
                return this._permissionSetOption;
            }
            set {
                this._permissionSetOption = value;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
