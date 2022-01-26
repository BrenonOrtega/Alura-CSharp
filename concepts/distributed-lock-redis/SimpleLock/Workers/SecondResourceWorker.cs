using Microsoft.Extensions.Logging;
using SimpleLock.Processors;

namespace SimpleLock.Workers
{
    class SecondResourceWorker : ResourceWorker
    {
        public SecondResourceWorker(ILogger<ResourceWorker> logger, IResourceProcessor processor) : base(logger, processor)
        {
        }
    }
}