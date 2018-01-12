using System;
using System.Collections.Generic;

namespace OfaSchlupfer.ScriptDom {
    [System.Serializable]
    public sealed class ExternalFileFormatContainerOption : ExternalFileFormatOption {
        private List<ExternalFileFormatOption> _suboptions = new List<ExternalFileFormatOption>();

        public List<ExternalFileFormatOption> Suboptions {
            get {
                return this._suboptions;
            }
        }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            for (int i=0, count = this.Suboptions.Count; i < count; i++) {
                this.Suboptions[i].Accept(visitor);
            }
        }
    }
}
