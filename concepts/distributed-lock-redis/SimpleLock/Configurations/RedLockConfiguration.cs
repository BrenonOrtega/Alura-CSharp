using System;

namespace SimpleLock.Configuration
{
    public class RedLockConfiguration
    {
        private int acquireWaitTime;
        private int retryTime;
        private int expiryTime;

        public TimeSpan AcquireWaitTime { get => TimeSpan.FromSeconds(acquireWaitTime); set => acquireWaitTime = (int)value.TotalMinutes; }
        public TimeSpan RetryTime {get => TimeSpan.FromSeconds(retryTime); set => retryTime = (int)value.TotalMinutes; }
        public TimeSpan ExpiryTime { get => TimeSpan.FromSeconds(expiryTime); set => expiryTime = (int)value.TotalMinutes; }
    }
}