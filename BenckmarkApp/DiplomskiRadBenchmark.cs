using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenckmarkApp
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DiplomskiRadBenchmark
    {
        private HttpClient _httpClient;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5251");
        }

        [Benchmark]
        public async Task Dapper()
        {
            for (int i = 0; i < 100; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/api/emisijedapper");
                //string bodyContent = "{ }";
                //var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
                //request.Content = content;

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        [Benchmark]
        public async Task EFC()
        {
            for (int i = 0; i < 100; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "/api/emisijeefc");
                //string bodyContent = "{ }";
                //var content = new StringContent(bodyContent, Encoding.UTF8, "application/json");
                //request.Content = content;

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _httpClient.Dispose();
        }
    }
}
