using Data.Models;

using Infrastructure;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeBaseProvider : IEmployeeBaseProvider
    {
        private readonly EmployeeApiConfiguration _employeeApiConfiguration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMemoryCache _memoryCache;
        private const string CacheKey = "AllEmployees";

        public EmployeeBaseProvider(IOptions<EmployeeApiConfiguration> employeeApiOptions, [NotNull] IHttpClientFactory httpClientFactory, IMemoryCache memoryCache)
        {
            _employeeApiConfiguration = employeeApiOptions.Value;
            _httpClientFactory = httpClientFactory;
            _memoryCache = memoryCache;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<IEmployeeBase>> GetEmployeeBaseListAsync(int? id = null)
        {
            var allEmployees = await GetFromCache(CacheKey, GetEmployeesAsync);

            if (id.HasValue)
            {
                var rslt = allEmployees.FirstOrDefault(e => e.id == id);
                if (rslt == null)
                    return (IEnumerable<IEmployeeBase>)(new IEmployeeBase[0]);

                return (IEnumerable<IEmployeeBase>)(new IEmployeeBase[] { rslt });
            }

            return (IEnumerable<IEmployeeBase>)allEmployees;
        }

        private async Task<IEnumerable<IEmployeeBase>> GetEmployeesAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("EmployeeClient");
            var result = await httpClient.GetAsync(_employeeApiConfiguration.apiUrl);

            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                var predictionResponse = JsonSerializer.Deserialize<EmployeeBase[]>(response);

                return predictionResponse;
            }
            else
            {
                throw new Exception();
            }
        }

        private async Task<IEnumerable<T>> GetFromCache<T>(string cacheKey, Func<Task<IEnumerable<T>>> fetch)
        {
            if (!_memoryCache.TryGetValue(cacheKey, out var result))
            {
                result = await fetch();
                _memoryCache.Set(cacheKey, result, DateTime.Now.AddYears(1));
            }

            return (IEnumerable<T>)result;
        }
    }
}
