using BeruTask.Server.Models;
using BeruTask.Server.Services.Interfaces;
using System.Net;

namespace BeruTask.Server.Services
{
    public class GetDataService:IGetDataService
    {
        private readonly IHttpClientFactory _clientFactory;

        public GetDataService(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task<GoldPriceModel> GetDataAsync(RequestModel requestModel)
        {
            HttpClient client = this._clientFactory.CreateClient("nbp");
            try
            {
                string startDate = requestModel.startDate.ToString("yyyy-MM-dd");
                string endDate = requestModel.endDate.ToString("yyyy-MM-dd");
                string requestUri = string.Format(startDate + "/" + endDate);
                CancellationToken cancellationToken = new CancellationToken();
                List<NBPResponseModel> goldPrices = await client.GetFromJsonAsync<List<NBPResponseModel>>(requestUri, cancellationToken);
                if (goldPrices != null)
                    return this.prepareData(goldPrices, requestModel);
            }
            catch (HttpRequestException ex)
            {
                if (!ex.Message.Contains(HttpStatusCode.Unauthorized.ToString()))
                {

                }
            }
            return null;
        }

        public GoldPriceModel prepareData(List<NBPResponseModel> nrbData, RequestModel requestModel)
        {
            return new GoldPriceModel()
            {
                StartDate = requestModel.startDate,
                EndDate = requestModel.endDate,
                StartPrice = nrbData.First<NBPResponseModel>().cena,
                EndPrice = nrbData.Last<NBPResponseModel>().cena,
                AvgPrice = Math.Round(nrbData.Select<NBPResponseModel, double>((Func<NBPResponseModel, double>)(x => x.cena)).Average(), 2),
                SaveDate = DateTime.Now
            };
        }
    }
}
