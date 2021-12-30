using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace generic.app.common.Dtos
{
    /// <summary>
    /// Class RespuestaServicio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Jhon Steven Pavon Bedoya</remarks>
    [ExcludeFromCodeCoverage]
    public class ResponseService<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ResponseService{T}" /> is estado.
        /// </summary>
        /// <value><c>true</c> if estado; otherwise, <c>false</c>.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public bool Status { get; set; }
        /// <summary>
        /// Gets or sets the tipo.
        /// </summary>
        /// <value>The tipo.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public HttpStatusCode HttpStatusCode { get; set; }
        /// <summary>
        /// Gets or sets the mensaje.
        /// </summary>
        /// <value>The mensaje.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the datos.
        /// </summary>
        /// <value>The datos.</value>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public T Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseService{T}" /> class.
        /// </summary>
        /// <remarks>Jhon Steven Pavon Bedoya</remarks>
        public ResponseService()
        {
            Status = false;
            Message = string.Empty;
        }
    }
}
