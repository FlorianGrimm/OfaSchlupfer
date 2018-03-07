namespace System.Collections.Generic {
    public static class DictionaryExtension {
        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
        /// <param name="that">this - if null <paramref name="defaultValue"/> is returned.</param>
        /// <param name="key">The key of the value to get - if null <paramref name="defaultValue"/> is returned.</param>
        /// <param name="defaultValue">the value to return if not found.</param>
        /// <returns>
        ///     When this method returns, contains the value associated with the specified key,
        ///     if the key is found; otherwise, the <paramref name="defaultValue"/>.
        /// </returns>
        public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> that, TKey key, TValue defaultValue = default(TValue)) {
            TValue result = defaultValue;
            if ((ReferenceEquals(that, null)) || (ReferenceEquals(key, null))) {
                return defaultValue;
            } else if ((that.TryGetValue(key, out result))) {
                    return result;
            } else {
                return defaultValue;
            }
        }
    }
}
