using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class MirrorToClause : TSqlFragment {
        private List<DeviceInfo> _devices = new List<DeviceInfo>();

        public List<DeviceInfo> Devices {
            get {
                return this._devices;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            for (int i=0, count = this.Devices.Count; i < count; i++) {
                this.Devices[i].Accept(visitor);
            }
            base.AcceptChildren(visitor);
        }
    }
}
