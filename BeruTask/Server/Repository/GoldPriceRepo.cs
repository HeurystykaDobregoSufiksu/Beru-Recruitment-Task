using BeruTask.Server.DataAccess;
using BeruTask.Server.Models;
using BeruTask.Server.Repository.Interfaces;

namespace BeruTask.Server.Repository
{
    public class GoldPriceRepo:IGoldPriceRepo
    {
        private readonly GoldPriceContext _context;

        public GoldPriceRepo(GoldPriceContext context) => this._context = context;

        public async Task<bool> SaveData(GoldPriceModel saveDataModel)
        {
            await this._context.AddAsync<GoldPriceModel>(saveDataModel);
            return await this._context.SaveChangesAsync() != -1;
        }
    }
}
