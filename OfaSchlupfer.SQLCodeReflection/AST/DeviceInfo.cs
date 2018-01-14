namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class DeviceInfo : TSqlFragment {
        private IdentifierOrValueExpression _logicalDevice;

        private ValueExpression _physicalDevice;

        public IdentifierOrValueExpression LogicalDevice {
            get {
                return this._logicalDevice;
            }

            set {
                this.UpdateTokenInfo(value);
                this._logicalDevice = value;
            }
        }

        public ValueExpression PhysicalDevice {
            get {
                return this._physicalDevice;
            }

            set {
                this.UpdateTokenInfo(value);
                this._physicalDevice = value;
            }
        }

        public DeviceType DeviceType { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            if (this.LogicalDevice != null) {
                this.LogicalDevice.Accept(visitor);
            }
            if (this.PhysicalDevice != null) {
                this.PhysicalDevice.Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
