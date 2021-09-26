using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;

namespace FileReaderBinding
{
    [Extension("FileReaderBinding")]
    public class FileReaderBinding : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            var rule = context.AddBindingRule<FileReaderBindingAttribute>();
            rule.BindToInput<FileReaderModel>(BuildFromAttribute);
        }

        private async Task<FileReaderModel> BuildFromAttribute(FileReaderBindingAttribute arg1, ValueBindingContext arg2)
        {
            string content = string.Empty;
            if (File.Exists(arg1.Location))
            {
                content = await File.ReadAllTextAsync(arg1.Location);
            }

            return new FileReaderModel
            {
                FullFilePath = arg1.Location,
                Content = content
            };
        }
    }
}
