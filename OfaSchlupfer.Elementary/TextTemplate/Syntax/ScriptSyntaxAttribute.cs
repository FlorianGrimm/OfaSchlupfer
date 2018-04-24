
using System;
using OfaSchlupfer.TextTemplate.Helpers;
using System.Reflection;

namespace OfaSchlupfer.TextTemplate.Syntax {
    public class ScriptSyntaxAttribute : Attribute {
        private ScriptSyntaxAttribute() {
        }

        public ScriptSyntaxAttribute(string name, string example) {
            Name = name;
            Example = example;
        }

        public string Name { get; }

        public string Example { get; }

        public static ScriptSyntaxAttribute Get(object obj) {
            if (obj == null) return null;
            return Get(obj.GetType());
        }

        public static ScriptSyntaxAttribute Get(Type type) {
            if (type == null) throw new ArgumentNullException(nameof(type));

            var attribute = type.GetTypeInfo().GetCustomAttribute<ScriptSyntaxAttribute>() ??
                            new ScriptSyntaxAttribute(type.Name, "...");
            return attribute;
        }
    }
}