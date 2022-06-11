using Azure.Storage.Blobs;
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
        [FunctionName("OverlayRadiant")]
        public IActionResult OverlayRadiant(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "overlay/radiant/{token}")] HttpRequest req, string token,
            [Blob("drafts/radiant-{token}.png", FileAccess.Read)] BlobClient client,
            ILogger log)
        {
            if (client == null)
                return new BadRequestResult();

            if (!client.CanGenerateSasUri)
                return new BadRequestResult();

            // 

            var uri = client.GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, expiresOn: System.DateTimeOffset.UtcNow.AddHours(1));
            return new ContentResult { Content = $"<html><head><META HTTP-EQUIV=\"refresh\" CONTENT=\"10\"><style>body {{ background - color: rgba(0, 0, 0, 0); margin: 0px auto; overflow: hidden; }}</style></head><body><img src=\"{uri}\" /></body></html>", ContentType = "text/html" };
        }

        [FunctionName("OverlayDire")]
        public IActionResult OverlayDire(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "overlay/dire/{token}")] HttpRequest req, string token,
            [Blob("drafts/dire-{token}.png", FileAccess.Read)] BlobClient client,
            ILogger log)
        {
            if (client == null)
                return new BadRequestResult();

            if (!client.CanGenerateSasUri)
                return new BadRequestResult();

            var uri = client.GenerateSasUri(Azure.Storage.Sas.BlobSasPermissions.Read, expiresOn: System.DateTimeOffset.UtcNow.AddHours(1));
            return new ContentResult { Content = $"<html><head><META HTTP-EQUIV=\"refresh\" CONTENT=\"10\"><style>body {{ background - color: rgba(0, 0, 0, 0); margin: 0px auto; overflow: hidden; }}</style></head><body><img src=\"{uri}\" /></body></html>", ContentType = "text/html" };
        }
    }
}