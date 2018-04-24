
using OfaSchlupfer.TextTemplate.Parsing;

namespace OfaSchlupfer {
    /// <summary>
    /// Defines the options used for rendering back an AST/<see cref="ScriptNode"/> to a text.
    /// </summary>
    public struct TemplateRewriterOptions {
        /// <summary>
        /// The mode used to render back an AST
        /// </summary>
        public ScriptMode Mode;
    }
}