using FileReaderBinding;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;

[assembly: WebJobsStartup(typeof(FileReaderBindingStartup))]
namespace FileReaderBinding
{
    public class FileReaderBindingStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddFileReaderBinding();
        }
    }
}
