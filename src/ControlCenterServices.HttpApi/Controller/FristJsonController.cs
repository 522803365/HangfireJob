
using ControlCenterServices.Application;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace ControlCenterServices.HttpApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FristJsonController : AbpController
    {
        private readonly IFristJsonService _FristJsonService;

        public FristJsonController(IFristJsonService FristJsonService)
        {
            _FristJsonService = FristJsonService;
        }

        [HttpGet]
        public string FristJson()
        {
            return _FristJsonService.FristJson();
        }
    }
}
