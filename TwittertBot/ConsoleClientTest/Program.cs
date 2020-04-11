using System;

using TwittertBot.Client;

namespace ConsoleClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var t = ClientImpl.FindPopularTweetByHashTag("#justsaying");
            Console.WriteLine(t);
        }
    }
}
