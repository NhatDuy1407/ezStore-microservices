using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microservice.Service.UserService.Mapper;
using Microsoft.Extensions.Configuration;

namespace Microservice.Service.UserService.WriteSide
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ServiceMapperProfile>();
            });

            Task.Factory.StartNew(() =>
            {
                var requestService = new UserRequestService(configuration);
                requestService.Start();
            });

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
