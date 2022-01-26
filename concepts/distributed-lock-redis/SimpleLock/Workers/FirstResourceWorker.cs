using System;
using Microsoft.Extensions.Logging;
using SimpleLock.Processors;

namespace SimpleLock.Workers
{
    class FirstResourceWorker : ResourceWorker
    {
        public FirstResourceWorker(ILogger<ResourceWorker> logger, IResourceProcessor processor) : base(logger, processor)
        {
        }
    }
}