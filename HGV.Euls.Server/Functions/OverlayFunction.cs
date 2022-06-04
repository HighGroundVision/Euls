using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace HGV.Euls.Server.Functions
{
    public class OverlayFunction
    {
        [FunctionName("Overlay")]
        public async Task<IActionResult> Overlay(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "overlay/{token}")] HttpRequest req,
            string token,
            [Blob("drafts/{token}.png", FileAccess.Read)] Stream stream,
            ILogger log)
        {
            using var ms = new MemoryStream();
            await stream.CopyToAsync(ms);
            return new FileContentResult(ms.ToArray(), "image/png") { FileDownloadName = "draft.png" };
        }

        [FunctionName("Layout")]
        public async Task<IActionResult> Layout(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "layout/{token}")] HttpRequest req,
            string token,
            ILogger log)
        {
            var url = $"/api/overlay/{token}";
            return new ContentResult { Content = $"<html><head></head><body><img src=\"{url}\" /></body></html>", ContentType = "text/html" };
        }
    }
}