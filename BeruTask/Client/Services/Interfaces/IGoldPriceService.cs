
using BeruTask.Shared;

namespace BeruTask.Client.Services.Interfaces
{
    public interface IGoldPriceService
    {
        event Action<ResponseModel<GoldPriceDto>> OnGetData;
        public event Action<string> HondleError;

        Task getData(RequestModel requestModel);
    }
}
