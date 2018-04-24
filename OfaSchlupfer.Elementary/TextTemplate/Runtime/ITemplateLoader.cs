﻿using OfaSchlupfer.TextTemplate.Parsing;

namespace OfaSchlupfer.TextTemplate.Runtime {
    /// <summary>
    /// Interface used for loading a template.
    /// </summary>
    public interface ITemplateLoader {
        /// <summary>
        /// Gets an absolute path for the specified include template name. Note that it is not necessarely a path on a disk, 
        /// but an absolute path that can be used as a dictionary key for caching)
        /// </summary>
        /// <param name="context">The current context called from</param>
        /// <param name="callerSpan">The current span called from</param>
        /// <param name="templateName">The name of the template to load</param>
        /// <returns>An absolute path or unique key for the specified template name</returns>
        string GetPath(TemplateContext context, SourceSpan callerSpan, string templateName);

        /// <summary>
        /// Loads a template using the specified template path/key.
        /// </summary>
        /// <param name="context">The current context called from</param>
        /// <param name="callerSpan">The current span called from</param>
        /// <param name="templatePath">The path/key previously returned by <see cref="GetPath"/></param>
        /// <returns>The content string loaded from the specified template path/key</returns>
        string Load(TemplateContext context, SourceSpan callerSpan, string templatePath);
    }
}