using System.IO;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace LessServer
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [BlobTrigger("samples-workitems/{name}")] Stream myBlob, 
            [Blob("profile/{name}", FileAccess.Write)] Stream image,
            string name, 
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            string[] imgExt = new string[] { "jpg", "jpeg", "png" };

            if (imgExt.Any(i=>name.Contains(i)))
            {
                log.LogInformation($"Image detected, copy to profile");

                myBlob.CopyTo(image);          
            }
        }
    }
}
