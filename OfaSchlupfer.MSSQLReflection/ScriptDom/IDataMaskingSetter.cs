namespace OfaSchlupfer.ScriptDom {
    internal interface IDataMaskingSetter {
        bool IsMasked {
            get;
            set;
        }

        StringLiteral MaskingFunction {
            get;
            set;
        }
    }
}
