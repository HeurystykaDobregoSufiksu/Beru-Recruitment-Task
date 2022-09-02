using BeruTask.Server.Models;
using BeruTask.Shared;

namespace BeruTask.Server.Services.Interfaces
{
    public interface IGetDataService
    {
        Task<GoldPriceModel> GetDataAsync(RequestModel requestModel);

    }
}
