using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Dtos;
using WeCare_Api.Modals;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MasterTableController : ControllerBase
    {
        private readonly IAppService _appService;
        private readonly IMapper _mapper;

        public MasterTableController(IAppService appService, IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Master.Appointment)]
        public async Task<IActionResult> GetAppointmentAsync()
        {
            var appointment = await _appService.GetAppointmentAsync();
            var data = _mapper.Map<IEnumerable<AppointmentDto>>(appointment);
            return Ok(data);
        }

        [HttpGet(ApiRoute.Master.Area)]
        public async Task<IActionResult> GetAreaAsync()
        {
            var area = await _appService.GetAreaAsync();
            var data = _mapper.Map<IEnumerable<AreaDto>>(area);
            return Ok(data);
        }

        [HttpGet(ApiRoute.Master.City)]
        public async Task<IActionResult> GetCityAsync()
        {
            var city = await _appService.GetCityAsync();
            var data = _mapper.Map<IEnumerable<CityDto>>(city);
            return Ok(data);
        }
    }
}
