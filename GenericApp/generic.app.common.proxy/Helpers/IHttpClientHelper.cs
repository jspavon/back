using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace generic.app.common.proxy.Helpers
{
    /// <summary>
    /// Interface IHttpClientHelper
    /// </summary>
    /// <remarks>Jhon Steven Pavón Bedoya</remarks>
    public interface IHttpClientHelper
    {
        /// <summary>
        /// Gets the string asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        Task<string> GetStringAsync(string uri, IDictionary<string, string> headers,string token = null);

        /// <summary>
        /// Posts the asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="method">The method.</param>
        /// <param name="item">The item.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        Task<HttpResponseMessage> PostPutAsync<T>(string uri, IDictionary<string, string> headers, HttpMethod method, T item, string token = null);


        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="method">The method.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;HttpResponseMessage&gt;.</returns>
        /// <remarks>Jhon Steven Pavón Bedoya</remarks>
        Task<HttpResponseMessage> DeleteAsync(string uri, IDictionary<string, string> headers, HttpMethod method, string token = null);

        /// <summary>
        /// Gets the byte array asynchronous.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="token">The token.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        Task<byte[]> GetByteArrayAsync(string uri, IDictionary<string, string> headers, string token);
    }
}
