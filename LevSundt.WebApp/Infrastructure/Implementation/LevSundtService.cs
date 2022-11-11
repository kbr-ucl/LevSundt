using LevSundt.WebApp.Infrastructure.Contract;
using LevSundt.WebApp.Infrastructure.Contract.Dto;

namespace LevSundt.WebApp.Infrastructure.Implementation;

public class LevSundtService : ILevSundtService
{
    private readonly HttpClient _httpClient;

    public LevSundtService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    async Task ILevSundtService.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Bmi", bmiCreateRequestDto);

        if(response.IsSuccessStatusCode)  return;
        
        var message = await response.Content.ReadAsStringAsync();
        throw new Exception(message);
    }

    async Task ILevSundtService.Edit(BmiEditRequestDto bmiEditRequestDto)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Bmi", bmiEditRequestDto);

        if(response.IsSuccessStatusCode) return;

        var messages = await response.Content.ReadAsStringAsync();
        throw new Exception(messages);
    }

    async Task<BmiQueryResultDto?> ILevSundtService.Get(int id, string userId)
    {
        return await _httpClient.GetFromJsonAsync<BmiQueryResultDto>($"api/Bmi/{id}/{userId}");
    }

    async Task<IEnumerable<BmiQueryResultDto>?> ILevSundtService.GetAll(string userId)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<BmiQueryResultDto>>($"api/Bmi/{userId}");
    }
}