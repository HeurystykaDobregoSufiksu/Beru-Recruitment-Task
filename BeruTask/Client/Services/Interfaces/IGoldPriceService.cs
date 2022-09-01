using BeruTask.Client.Models;
using BeruTask.Shared;

namespace BeruTask.Client.Services.Interfaces
{
    public interface IGoldPriceService
    {
        event Action<GoldPriceDto> OnGetData;

        Task<GoldPriceDto> getData(RequestModel requestModel);
    }
}
