using BeruTask.Server.Models;
using BeruTask.Server.Services.Interfaces;
using BeruTask.Shared;
using System.Net;

namespace BeruTask.Server.Services
{
    public class GetDataService : IGetDataService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<GetDataService> _logger;
        private readonly IConfiguration _config;

        public GetDataService(IHttpClientFactory clientFactory, ILogger<GetDataService> logger, IConfiguration config)
        {
            this._clientFactory = clientFactory;
            _logger = logger;
            _config = config;
        }

        public async Task<GoldPriceModel> GetDataAsync(RequestModel requestModel)
        {
            HttpClient client = this._clientFactory.CreateClient("nbp");

            string startDate = requestModel.startDate.ToString("yyyy-MM-dd");
            string endDate = requestModel.endDate.ToString("yyyy-MM-dd");
            string requestUri = string.Format(startDate + "/" + endDate);
            CancellationToken cancellationToken = new CancellationToken();
            List<NBPResponseModel> goldPrices = await client.GetFromJsonAsync<List<NBPResponseModel>>(requestUri, cancellationToken);
            client.Dispose();
            if (goldPrices != null)
            {
                _logger.LogInformation(_config.GetSection("LogInfo").GetSection("com_nbpSucc").ToString() + DateTime.Now);
                return this.prepareData(goldPrices, requestModel);
            }
            else { return null; }
          
        }

        private GoldPriceModel prepareData(List<NBPResponseModel> nrbData, RequestModel requestModel)
        {
            return new GoldPriceModel()
            {
           
                StartPrice = nrbData.First<NBPResponseModel>().cena,
                EndPrice = nrbData.Last<NBPResponseModel>().cena,
                AvgPrice = Math.Round(nrbData.Select<NBPResponseModel, double>((Func<NBPResponseModel, double>)(x => x.cena)).Average(), 2),
                SaveDate = DateTime.Now
            };
        }
    }
}
