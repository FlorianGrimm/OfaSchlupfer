namespace OfaSchlupfer.Freezable {
    using System;
    using System.Collections.Generic;

    public interface IFreezableOwned2KeyedCollection<TKey1, TKey2, TValue>
        : IFreezable
        , IList<TValue>
        , IFreezableOwnedKeyedCollection<TKey1, TValue>
        where TKey1 : class, IEquatable<TKey1>
        where TKey2 : class, IEquatable<TKey2>
        where TValue : class {

        //List<TValue> FindByKey(TKey1 key);
        List<TValue> FindByKey2(TKey2 key);
        //TValue GetValueOrDefault(TKey1 key, TValue defaultValue = default(TValue));
        TValue GetValueOrDefault2(TKey2 key, TValue defaultValue = default(TValue));
    }
}
