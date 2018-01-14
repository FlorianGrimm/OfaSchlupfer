namespace OfaSchlupfer.AST {
    [System.Serializable]
    public sealed class RemoteDataArchiveDbFederatedServiceAccountSetting : RemoteDataArchiveDatabaseSetting {
        public bool IsOn { get; set; }

        public override void Accept(TSqlFragmentVisitor visitor) => visitor?.ExplicitVisit(this);
    }
}
