using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisEventSourcing.Infra.Extensions;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Xunit;

namespace RedisEventSourcing.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task Persisting_DataInCache_Should_Pass()
        {
            var connectionString = "localhost:6379";
            var redisConfigs = new Dictionary<string, string>
            {
                { "ConnectionStrings:Redis", connectionString },
                { "Redis:Password", "Redis2021!" },
                { "Redis:Database", "0" },
                { "Redis:InstanceName", "TestInstanceName" }
            };

            var config = new ConfigurationBuilder().AddInMemoryCollection(redisConfigs).Build();
            var provider = new ServiceCollection().AddRedisCaching(config).BuildServiceProvider();

            var cache = provider.GetRequiredService<IDistributedCache>();

            var expected = new { Id = "123#abc", Value = "hello, im the expected string" };

            await cache.SetStringAsync(expected.Id, expected.Value);

            var actual = await cache.GetStringAsync(expected.Id);
            Assert.Equal(expected.Value, actual);
        }
    }
}
