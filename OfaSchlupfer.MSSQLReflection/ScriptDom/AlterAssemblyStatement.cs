namespace OfaSchlupfer.ScriptDom {
    using System.Collections.Generic;

    [System.Serializable]
    public sealed class AlterAssemblyStatement : AssemblyStatement {
        public List<Literal> DropFiles { get; } = new List<Literal>();

        public bool IsDropAll { get; set; }

        public List<AddFileSpec> AddFiles { get; } = new List<AddFileSpec>();

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);

        public override void AcceptChildren(TSqlFragmentVisitor visitor) {
            base.AcceptChildren(visitor);
            var dropFiles = this.DropFiles;
            for (int i = 0, count = dropFiles.Count; i < count; i++) {
                dropFiles[i].Accept(visitor);
            }

            var addFiles = this.AddFiles;
            for (int i = 0, count = addFiles.Count; i < count; i++) {
                addFiles[i].Accept(visitor);
            }
        }
    }
}
