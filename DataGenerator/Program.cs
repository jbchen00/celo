using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataGenerator
{
    class Program
    {
        public static IConfiguration Configuration
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", false, true)
                    .AddEnvironmentVariables();
                return builder.Build();
            }
        }

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("SampleApp.Program", LogLevel.Debug)
                    .AddConsole();
            }
        );

        static void Main(string[] args)
        {
            InsertData().GetAwaiter().GetResult();
        }

        private static async Task InsertData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://randomuser.me/api/?results=5000");
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<RandomUserResponse>(body,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            var connectionString = Configuration.GetConnectionString("Database");
            var dbContextOptionsBuilder =
                new DbContextOptionsBuilder<MyDbContext>()
                    .UseLoggerFactory(loggerFactory)
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(connectionString);
            var context = new MyDbContext(dbContextOptionsBuilder.Options);
            var userEntity = result.Users.Select(Map);
            var userRepo = new UserRepository(context);
            await userRepo.CreateUsers(userEntity);
        }

        private static UserEntity Map(RUser user)
        {
            return new UserEntity()
            {
                Title = user.Name.Title,
                FirstName = user.Name.First,
                LastName = user.Name.Last,
                Email = user.Email,
                PhoneNumber = user.Phone,
                DateOfBirth = user.DateOfBirth.Date,
                ProfileImage = new ProfileImageEntity()
                {
                    Thumbnail = user.Picture.Thumbnail,
                    Large = user.Picture.Large
                }
            };
        }
    }

    internal class RandomUserResponse
    {
        [JsonPropertyName("results")] public IEnumerable<RUser> Users { get; set; }
    }

    internal class RUser
    {
        public RName Name { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("dob")] public RDob DateOfBirth { get; set; }
        public string Phone { get; set; }
        public RPicture Picture { get; set; }
    }

    internal class RPicture
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }

    internal class RDob
    {
        public DateTime Date { get; set; }
    }

    internal class RName
    {
        public string Title { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}