namespace OfaSchlupfer.AST {
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
