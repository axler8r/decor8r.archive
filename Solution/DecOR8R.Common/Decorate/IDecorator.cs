using System;

namespace DecOR8R.Common
{
    /// <summary>
    /// Decorates subjects for the appropriate targtes.
    /// </summary>
    /// <typeparam name="K">The key type</typeparam>
    /// <typeparam name="V">The value type</typeparam>
    public interface IDecorator<K, V> where V: IConvertible
    {
        /// <summary>
        /// Decorate the subject
        /// </summary>
        /// <param name="subject">The thing to decorate</param>
        /// <returns>The decorated thing</returns>
        string Decorate(IDecoratable subject);
    }
}
