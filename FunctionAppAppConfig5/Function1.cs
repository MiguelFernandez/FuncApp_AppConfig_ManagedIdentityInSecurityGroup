using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FunctionAppAppConfig5
{
    public class Function1
    {
        private readonly ILogger _logger;
        private IConfiguration _configuration;


        public Function1(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _configuration = configuration;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            var nameOfSetting = "TestSetting1";
            var set = _configuration.GetValue<string>(nameOfSetting);
            response.WriteString($"Setting {nameOfSetting} |  value:  {set}");

            return response;
        }
    }
}
