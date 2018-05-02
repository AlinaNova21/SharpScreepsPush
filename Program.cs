using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var input = new StringReader(TestConfig);

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            var config = deserializer.Deserialize<Config>(input);
            var server = config.Servers["screepsplus"]; 
            Console.WriteLine(server.Host);
        }

        private const string TestConfig = @"---
            servers:
                screepsplus:
                    host: server1.screepspl.us
                    port: 443
                    secure: true
                    username: agstest
                    password: notmypass
            configs:
                push:
                    src: src
                    branch: testing
            ";
    }

    class Config {
        public Dictionary<String,Server> Servers { get; set; }
        public Dictionary<String,Object> Configs { get; set; }
    }

    class Server {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Secure { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
