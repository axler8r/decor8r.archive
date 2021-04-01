using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecOR8R.Common
{
    /// <summary>
    /// Manage configuration information.
    /// </summary>
    public interface IConfigurator
    {
        /// <summary>
        /// Read configuration information.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="file">Configuration file</param>
        /// <returns>A configuration object</returns>
        IConfigurable<K, V> Read<K, V>(FileSystemInfo file)
            where K : notnull
            where V : notnull, IConvertible;

        /// <summary>
        /// Write configuration information.
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="configuration">Configuration data</param>
        /// <param name="file">Conficuration file</param>
        void Write<K, V>(IConfigurable<K, V> configuration, FileSystemInfo file)
            where K : notnull
            where V : notnull, IConvertible;
    }
}
