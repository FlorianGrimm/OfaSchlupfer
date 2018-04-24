using System.Collections.Generic;

namespace OfaSchlupfer.TextTemplate.Syntax {
    /// <summary>
    /// Interfaces used by statements/expressions that have special trailing parameters (for, tablerow, include...)
    /// </summary>
    public interface IScriptNamedArgumentContainer {
        List<ScriptNamedArgument> NamedArguments { get; set; }
    }
}