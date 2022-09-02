
using BeruTask.Shared;
using System.Net;

namespace BeruTask.Client.Services.Interfaces
{
    public interface IGoldPriceService
    {
        event Action<ResponseModel<GoldPriceDto>> OnGetData;
        public event Action<string> DisplayMessage;

        Task getData(RequestModel requestModel);
    }
}
