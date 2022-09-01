using BeruTask.Server.Models;

namespace BeruTask.Server.Repository.Interfaces
{
    public interface IGoldPriceRepo
    {
        Task<bool> SaveData(GoldPriceModel saveDataModel);
    }
}
