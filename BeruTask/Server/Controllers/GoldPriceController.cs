using BeruTask.Server.Models;
using BeruTask.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeruTask.Shared;
using System.Net;

namespace BeruTask.Server.Controllers
{
    
    [ApiController]
    public class GoldPriceController : ControllerBase
    {
        private readonly ISaveDataService _saveDataService;
        private readonly IGetDataService _getDataService;
        private readonly IMapper _mapper;

        public GoldPriceController(ISaveDataService saveDataService, IGetDataService getDataService, IMapper mapper)
        {
            _saveDataService = saveDataService;
            _getDataService = getDataService;
            _mapper = mapper;
        }

        [HttpPost("api/prices")]
        public async Task<ActionResult<ResponseModel<GoldPriceDto>>> Prices([FromBody] RequestModel model)
        {
            GoldPriceModel data;

            try
            {
                data = await _getDataService.GetDataAsync(model);
            }
            catch (HttpRequestException ex)
            {

                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {

                }
                else if (ex.StatusCode == HttpStatusCode.NotFound)
                {

                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            data = null;
            var response = new ResponseModel<GoldPriceDto>();
            if (data != null)
            {
                response.Data = _mapper.Map<GoldPriceModel, GoldPriceDto>(data);
                    await this._saveDataService.SaveData(data);
                
            }
            return Ok(response);
        }
    }
}
