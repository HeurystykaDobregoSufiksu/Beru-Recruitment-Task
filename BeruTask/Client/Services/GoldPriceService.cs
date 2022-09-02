
using BeruTask.Client.Services.Interfaces;
using BeruTask.Shared;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;


namespace BeruTask.Client.Services
{
    public class GoldPriceService: IGoldPriceService
    {
        private readonly HttpClient _http;

        public event Action<ResponseModel<GoldPriceDto>> OnGetData;
        public event Action<string> DisplayMessage;
        public GoldPriceService(HttpClient http)
        {
            _http = http;
        }
        public async Task getData(RequestModel requestModel)
        {
            ResponseModel<GoldPriceDto> response=new ResponseModel<GoldPriceDto>();
            HttpResponseMessage res = await _http.PostAsJsonAsync<RequestModel>("api/prices", requestModel);
            if (res.StatusCode==HttpStatusCode.OK)
                response = JsonConvert.DeserializeObject<ResponseModel<GoldPriceDto>>(res.Content.ReadAsStringAsync().Result);
            else
            {
                if (DisplayMessage != null)
                    DisplayMessage(res.StatusCode.ToString());
            }
            Action<ResponseModel<GoldPriceDto>> onGetData = this.OnGetData;
            if (onGetData != null)
                onGetData(response);
        }
    }
}
