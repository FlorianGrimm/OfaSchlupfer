namespace OfaSchlupfer.AST {
    [System.Serializable]
    public abstract class SetOnOffStatement : TSqlStatement {
        public bool IsOn { get; set; }
    }
}
