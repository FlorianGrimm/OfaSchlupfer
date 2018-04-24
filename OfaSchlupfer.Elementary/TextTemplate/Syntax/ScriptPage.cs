
using OfaSchlupfer.TextTemplate.Parsing;

namespace OfaSchlupfer.TextTemplate.Syntax {
    public class ScriptPage : ScriptNode {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptPage"/> class.
        /// </summary>
        public ScriptPage() {
        }

        /// <summary>
        /// Gets or sets the front matter. May be <c>null</c> if script is not parsed using  <see cref="ScriptMode.FrontMatterOnly"/> or <see cref="ScriptMode.FrontMatterAndContent"/>. See remarks.
        /// </summary>
        /// <remarks>
        /// Note that this code block is not executed when evaluating this page. It has to be evaluated separately (usually before evaluating the page).
        /// </remarks>
        public ScriptBlockStatement FrontMatter { get; set; }

        public ScriptBlockStatement Body { get; set; }

        public override object Evaluate(TemplateContext context) {
            return context.Evaluate(Body);
        }

        public override void Write(TemplateRewriterContext context) {
            context.Write(Body);
        }
    }
}