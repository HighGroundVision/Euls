using HGV.Euls.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HGV.Euls.Server.Functions
{
    public class EventsFunction
    {
        [FunctionName("Events")]
        public async Task<IActionResult> Events(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "events")] HttpRequest req,
            [Queue("events")] IAsyncCollector<Root> events,
            ILogger log)
        {
            try
            {
                using var reader = new StreamReader(req.Body);
                var json = await reader.ReadToEndAsync();
                var root = JsonConvert.DeserializeObject<Root>(json);

                await events.AddAsync(root);
            } 
            catch(Exception ex)
            {
                log.LogError(ex, ex.Message);
            }

            return new OkResult();
        }
    }
}