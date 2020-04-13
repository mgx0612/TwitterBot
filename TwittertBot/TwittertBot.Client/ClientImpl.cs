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

    }

    public interface ITwitterOps
    {
        public ITweet FindPopularTweetByHashTag(string hashtag);
    }

    public class TwitterOpsImpl : ITwitterOps
    {
        private readonly string _key;
        private readonly string _secret;
        private readonly string _token;
        public TwitterOpsImpl(string key, string secret, string token)
        {
            _key = key;
            _secret = secret;
            _token = token;
        }


        public ITweet FindPopularTweetByHashTag(string hashtag)
        {
            return ClientImpl.FindPopularTweetByHashTag(this._key, this._secret, this._token, hashtag);
        }

    }

}
