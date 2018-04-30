namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections.Generic;

    public interface IFreezableOwnedKeyedCollection<TKey, TValue>
        : IFreezable
        , IList<TValue>
        where TKey : IEquatable<TKey>
        where TValue : class {

        void AddRange(IEnumerable<TValue> items);

        List<TValue> FindByKey(TKey key);

        TValue GetValueOrDefault(TKey key, TValue defaultValue = default(TValue));
    }
}