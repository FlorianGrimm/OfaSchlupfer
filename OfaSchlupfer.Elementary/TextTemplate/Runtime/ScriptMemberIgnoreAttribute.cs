using System;

namespace OfaSchlupfer.TextTemplate.Runtime {
    [AttributeUsage(AttributeTargets.Field| AttributeTargets.Property|AttributeTargets.Method)]
    public class ScriptMemberIgnoreAttribute : Attribute {

    }
}