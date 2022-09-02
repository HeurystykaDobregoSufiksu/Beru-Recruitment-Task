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
        private readonly IConfiguration _config;
        private readonly ILogger<GoldPriceController> _logger;

        public GoldPriceController(ISaveDataService saveDataService, IGetDataService getDataService, IMapper mapper, IConfiguration config, ILogger<GoldPriceController> logger)
        {
            _saveDataService = saveDataService;
            _getDataService = getDataService;
            _mapper = mapper;
            _config = config;
            _logger = logger;
        }

        [HttpPost("api/prices")]
        public async Task<ActionResult<ResponseModel<GoldPriceDto>>> Prices([FromBody] RequestModel model)
        {
            var response = new ResponseModel<GoldPriceDto>();
            
            try
            {
                GoldPriceModel data = await _getDataService.GetDataAsync(model);
                response.Data = _mapper.Map<GoldPriceModel, GoldPriceDto>(data);
                await this._saveDataService.SaveData(data);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(_config.GetSection("LogInfo").GetSection("err_nbpFailed").ToString() +ex.Message + DateTime.Now);
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    return BadRequest();
                }
                else if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }
    }
}
