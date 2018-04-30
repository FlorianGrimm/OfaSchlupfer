namespace OfaSchlupfer.Model {
    using System;
    using System.Collections.Generic;
    using System.Text;
    using OfaSchlupfer.Freezable;

    public class MetaMappingEntity 
        : FreezableObject {
        private MetaMappingComplexType _ComplexType;

        public MetaMappingComplexType ComplexType {
            get {
                return this._ComplexType;
            }
            set {
                this.ThrowIfFrozen(nameof(this.ComplexType));
                this._ComplexType = value;
            }
        }

        public override bool Freeze() {
            var result = base.Freeze();
            if (result) {
                this._ComplexType?.Freeze();
            }
            return result;
        }
    }
}
