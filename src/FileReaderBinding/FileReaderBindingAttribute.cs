using System;
using Microsoft.Azure.WebJobs.Description;

namespace FileReaderBinding
{
    [Binding]
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    public class FileReaderBindingAttribute : Attribute
    {
        [AutoResolve]
        public string Location { get; set; }
    }
}
