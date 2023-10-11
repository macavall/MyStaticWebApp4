using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MyStaticWebApp4
{
    public class http1
    {
        private readonly ILogger _logger;

        //public class ToDoItem
        //{
        //    public string id { get; set; }
        //    public string PartitionKey { get; set; }
        //}

        public class ToDoItemLookup
        {
            public string ToDoItemId { get; set; }

            public string ToDoItemPartitionKeyValue { get; set; }
        }

        public class ToDoItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("partitionKey")]
            public string PartitionKey { get; set; }

            public string Description { get; set; }
        }

        public http1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<http1>();
        }

        [Function("http1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        [CosmosDBInput(
        databaseName: "databaseName",
        containerName: "collectionName",
        Connection  = "cosmosconnstring",
        SqlQuery = "select * from Items r where r.id = 'replace_with_new_document_id4'")]
                IEnumerable<ToDoItem> toDoItems)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            //var response = req.CreateResponse(HttpStatusCode.OK);
           //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            //response.WriteString("Welcome to Azure Functions!");

            var tempResponse = "Welcome to Azure Functions!";

            var itemData = new { name = "name"};

            var response = req.CreateResponse(HttpStatusCode.OK);

            response.WriteAsJsonAsync(itemData);

            return response;

    }
    }
    public class ToDoItem
    {
        public string id { get; set; }
    }

    public class ResponseClass
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
