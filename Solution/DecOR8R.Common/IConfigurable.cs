using System;
using System.Collections.Generic;

namespace DecOR8R.Common
{
    /// <summary>
    /// Configuration data.
    /// </summary>
    /// <typeparam name="K">Configuration key</typeparam>
    /// <typeparam name="V">Conficuraiton value</typeparam>
    public interface IConfigurable<K, V>
        where K : notnull
        where V : notnull, IConvertible
    {
        /// <summary>
        /// Configuration data key-value table.
        /// </summary>
        IDictionary<K, V> Configuration { get; set; }

        /// <summary>
        /// Retrieve a value for the specified key.
        /// </summary>
        /// <param name="key">The key of the value we are looking for</param>
        /// <returns>The value as identified by the key</returns>
        V Value(K key);
    }
}

