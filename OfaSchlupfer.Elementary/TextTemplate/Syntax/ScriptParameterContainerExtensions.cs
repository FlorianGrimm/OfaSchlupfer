using System.Collections.Generic;

namespace OfaSchlupfer.TextTemplate.Syntax {
    public static class ScriptParameterContainerExtensions {
        public static void AddParameter(this IScriptNamedArgumentContainer container, ScriptNamedArgument argument) {
            if (container.NamedArguments == null) {
                container.NamedArguments = new List<ScriptNamedArgument>();
            }
            container.NamedArguments.Add(argument);
        }

        public static void Write(this TemplateRewriterContext context, List<ScriptNamedArgument> parameters) {
            if (parameters == null) {
                return;
            }
            for (var i = 0; i < parameters.Count; i++) {
                var option = parameters[i];
                context.ExpectSpace();
                context.Write(option);
            }
        }
    }
}