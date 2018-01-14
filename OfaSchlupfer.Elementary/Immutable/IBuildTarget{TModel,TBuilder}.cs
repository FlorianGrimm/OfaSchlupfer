namespace OfaSchlupfer.Elementary.Immutable {
    using System;

    /// <summary>
    /// Defines Get Builder
    /// </summary>
    /// <typeparam name="TModel">the model type</typeparam>
    /// <typeparam name="TBuilder">the build type</typeparam>
    public interface IBuildTarget<TModel, TBuilder> : IBuildTarget {
        TBuilder GetBuilder(bool clone, Action<TModel> setTarget, Action<TModel> setFrozen);
    }
}
