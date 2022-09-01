using BeruTask.Server.Models;

namespace BeruTask.Server.Services.Interfaces
{
    public interface IGetDataService
    {
        Task<GoldPriceModel> GetDataAsync(RequestModel requestModel);

    }
}
