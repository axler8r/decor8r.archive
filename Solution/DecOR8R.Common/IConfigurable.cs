using System;
using System.Collections.Generic;

namespace DecOR8R.Common
{
    /// <summary>
    /// Configuration data.
    /// </summary>
    /// <typeparam name="K">Configuration key</typeparam>
    /// <typeparam name="V">Conficuraiton value</typeparam>
    public interface IConfigurable<K, V> where V : IConvertible
    {
        /// <summary>
        /// Configuration data key-value table.
        /// </summary>
        public IDictionary<K, V> Configuration { get; set; }

        /// <summary>
        /// Retrieve a value for the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public V Value(K key);
    }
}
