using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TwittertBot.Client;

[assembly: FunctionsStartup(typeof(TwitterBot.ScheduleFunction.Startup))]

namespace TwitterBot.ScheduleFunction
{
    public class Startup : FunctionsStartup
    {
        private ITwitterOps createClient()
        {
            var key = "{api_key}";
            var secret = "{api_secret}";
            var token = "{bearer_token}";
            return new TwitterOpsImpl(key, secret, token);
        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton(s => createClient());
        }
    }
    public class FetchOldHashTagFunction
    {
        private readonly ITwitterOps _twitterClient;

        public FetchOldHashTagFunction(ITwitterOps client)
        {
            _twitterClient = client;
        }

        [FunctionName("FetchOldHashTagFunction")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            var t = _twitterClient.FindPopularTweetByHashTag("#justsaying");
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}, {t.ToString()}");
        }
    }
}
