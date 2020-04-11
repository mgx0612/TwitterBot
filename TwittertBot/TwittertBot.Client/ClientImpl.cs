using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TwittertBot.Client
{
    public static class ClientImpl
    {
        public static ITweet FindPopularTweetByHashTag(string key, string secret, string token, string hashtag)
        {
            Auth.SetApplicationOnlyCredentials(key, secret, token);
            ISearchTweetsParameters searchParams = Search.CreateTweetSearchParameter(hashtag);
            searchParams.SearchType = SearchResultType.Popular;
            searchParams.MaximumNumberOfResults = 1;
            var ts = Search.SearchTweets(searchParams);
            return ts.Any() ? ts.First() : null;
        }

        public static ITweet FindPopularTweetByHashTag(string hashtag)
        {
            var key = "api key";
            var secret = "api secret";
            var token = "bearer token";
            return FindPopularTweetByHashTag(key, secret, token, hashtag);
        }
    }
}
