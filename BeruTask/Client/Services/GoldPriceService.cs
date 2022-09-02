
using BeruTask.Client.Services.Interfaces;
using BeruTask.Shared;
using Newtonsoft.Json;
using System.Net.Http.Json;


namespace BeruTask.Client.Services
{
    public class GoldPriceService: IGoldPriceService
    {
        private readonly HttpClient _http;

        public event Action<GoldPriceDto> OnGetData;

        public GoldPriceService(HttpClient http)
        {
            _http = http;
        }
        public async Task<GoldPriceDto> getData(RequestModel requestModel)
        {
            GoldPriceDto returnValue = null;
            HttpResponseMessage res = await _http.PostAsJsonAsync<RequestModel>("api/prices", requestModel);
            if (res.IsSuccessStatusCode)
                returnValue = JsonConvert.DeserializeObject<GoldPriceDto>(res.Content.ReadAsStringAsync().Result);
            Action<GoldPriceDto> onGetData = this.OnGetData;
            if (onGetData != null)
                onGetData(returnValue);

            GoldPriceDto data = returnValue;

            returnValue = null;
            res = null;
            return data;
        }
    }
}
