using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http
{

    public class HttpCommandDataClient : ICommandDataClien
    {
        private readonly HttpClient _httpClient;

        public IConfiguration _configuration { get; }

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendPlatformToCommand(PlatformReadDtos plat)
        {
            var httpContent = new StringContent(

                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync Post to CommandService is Successfull");
            }
            else
            {
                Console.WriteLine("--> Sync Post to CommandService is Failed");
            }
        }

    }

}