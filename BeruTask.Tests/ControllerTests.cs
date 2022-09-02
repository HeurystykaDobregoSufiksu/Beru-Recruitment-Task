using Moq;
using Xunit;
using BeruTask.Server.Services.Interfaces;
namespace BeruTask.Tests
{
    public class ControllerTests
    {
       
        [Fact]
        public async System.Threading.Tasks.Task DateSpanTooLong()
        {
            Shared.RequestModel requestModel=new Shared.RequestModel();
           
            var mockIGetDataService = new Mock<IGetDataService>();
            mockIGetDataService.Setup(x => x.GetDataAsync(requestModel)).Throws(new System.Net.Http.HttpRequestException());
           
            var mockLogger = new Mock<Microsoft.Extensions.Logging.ILogger<Server.Controllers.GoldPriceController>>();
            var mockISaveDataService = new Mock<ISaveDataService>();
            var mockIMapper = new Mock<AutoMapper.IMapper>();
            var mockConfiguration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            var controller = new Server.Controllers.GoldPriceController(mockISaveDataService.Object, mockIGetDataService.Object, mockIMapper.Object, mockConfiguration.Object, mockLogger.Object);
            var res = await controller.Prices(requestModel);
         
            Assert.IsType<Microsoft.AspNetCore.Mvc.StatusCodeResult>(res);
        }
      
    }
}