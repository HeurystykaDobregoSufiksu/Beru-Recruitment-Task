using BeruTask.Server.DTOs;
using BeruTask.Server.Models;

namespace BeruTask.Server.Services.Interfaces
{
    public interface ISaveDataService
    {
        Task<bool> SaveData(GoldPriceModel saveDataModel);

        Task<bool> SaveDataToJsonFile(GoldPriceJsonDto saveDataModel);

        Task<bool> SaveDataToDB(GoldPriceModel saveDataModel);
    }
}
