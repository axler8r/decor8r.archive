using System;

namespace DecOR8R.Common
{
    /// <summary>
    /// Decorates subjects for the appropriate targtes.
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public interface IDecorator<K, V> where V: IConvertible
    {
        /// <summary>
        /// Configuration data to use during the decoration process.
        /// </summary>
        public IConfigurable<K, V> Configuration { get; }

        /// <summary>
        /// Decorate the subject
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public string Decorate(IDecoratable subject);
    }
}
