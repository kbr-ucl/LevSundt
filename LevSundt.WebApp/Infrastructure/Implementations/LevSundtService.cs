using LevSundt.WebApp.Infrastructure.Contracts;
using LevSundt.WebApp.Infrastructure.Contracts.Dtos;
using System.Net.Http.Json;

namespace LevSundt.WebApp.Infrastructure.Implementations;

public class LevSundtService : ILevSundtService
{
    private readonly HttpClient _httpClient;

    public LevSundtService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task<IEnumerable<BmiQueryResultDto>?> ILevSundtService.GetAll(string userId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<BmiQueryResultDto>>($"api/Bmi/{userId}");
    }

    async Task ILevSundtService.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        await _httpClient.PostAsJsonAsync($"api/Bmi", bmiCreateRequestDto);
    }

    async Task ILevSundtService.Edit(BmiEditRequestDto bmiEditRequestDto)
    {
        await _httpClient.PutAsJsonAsync($"api/Bmi", bmiEditRequestDto);
    }

    async Task<BmiQueryResultDto> ILevSundtService.Get(int id, string userId)
    {
        return await _httpClient.GetFromJsonAsync<BmiQueryResultDto>($"api/Bmi/{id}/{userId}");
    }
}