namespace OfaSchlupfer.ModelOData.Edm {
    public enum MultiplicityKind {
        /// <summary>
        /// `?
        /// </summary>
        Unknown,

        /// <summary>
        /// 0..1
        /// </summary>
        OneOptional,

        /// <summary>
        /// 1
        /// </summary>
        One,

        /// <summary>
        /// *
        /// </summary>
        Multiple
    }
}