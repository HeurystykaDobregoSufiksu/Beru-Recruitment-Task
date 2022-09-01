using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeruTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoldPriceController : ControllerBase
    {
       /* [HttpPost("api/prices")]
        public async Task<ActionResult<RequestModel>> Prices([FromBody] RequestModel model)
        {
            GoldPriceModel data = await this._getDataService.GetDataAsync(model);
            if (data != null)
            {
                bool res = await this._saveDataService.SaveData(data);
            }
            ActionResult<RequestModel> prices = (ActionResult<RequestModel>)(ActionResult)this.Ok((object)data);
            data = (GoldPriceModel)null;
            return prices;
        }*/
    }
}
