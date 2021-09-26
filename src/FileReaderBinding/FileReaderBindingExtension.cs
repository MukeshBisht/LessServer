using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;

namespace FileReaderBinding
{
    public static class FileReaderBindingExtension
    {
        public static IWebJobsBuilder AddFileReaderBinding(this IWebJobsBuilder builder)
        {
            if(builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<FileReaderBinding>();

            return builder;
        }
    }
}
