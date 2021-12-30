using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using generic.app.common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace generic.app.api.Filters
{
    [ExcludeFromCodeCoverage]
    public sealed class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<ExceptionFilter> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionFilter" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <exception cref="ArgumentNullException">configuration
        /// or
        /// logger</exception>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public ExceptionFilter(ILogger<ExceptionFilter> logger, IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Called after an action has thrown an <see cref="T:System.Exception" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext" />.</param>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public void OnException(ExceptionContext context)
        {
            var message = JsonConvert.SerializeObject(MessageError(context.Exception), Formatting.Indented);
            var objResponseService = new ResponseService<string>
            {
                Status = false,
                Message = HttpStatusCode.InternalServerError.ToString(),
                Data = message
            };


            _logger.LogError(context.Exception, message);


            context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(objResponseService, Formatting.Indented));
        }

        /// <summary>
        /// Messages the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="level">The level.</param>
        /// <returns>List&lt;ResponseException&gt;.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        private static List<ResponseException> MessageError(Exception ex, int level = 30)
        {
            var listError = new List<ResponseException>();
            var counter = 1;
            while (ex != null && counter <= level)
            {
                listError.Add(new ResponseException
                {
                    ErrorLevel = counter.ToString(),
                    ErrorMessage =  ex.Message,
                    ErrorSource = ex.Source,
                    ErrorStackTrace = ex.StackTrace,
                    ErrorTargetSite = ex.TargetSite?.ToString(),
                    ErrorData = ex.Data
                });
                ex = ex.InnerException;
                counter++;
            }
            return listError;
        }
    }
}
