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
        private readonly IAppRespiratory _appRespiratory;
        private readonly IMapper _mapper;

        public MasterTableController(IAppRespiratory appRespiratory, IMapper mapper)
        {
            _appRespiratory = appRespiratory;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Master.Appointment)]
        public async Task<IActionResult> GetAppointmentAsync()
        {
            var appointment = await _appRespiratory.GetAppointmentAsync();
            var data = _mapper.Map<IEnumerable<AppointmentDto>>(appointment);
            return Ok(data);
        }

        [HttpGet(ApiRoute.Master.Area)]
        public async Task<IActionResult> GetAreaAsync()
        {
            var area = await _appRespiratory.GetAreaAsync();
            var data = _mapper.Map<IEnumerable<AreaDto>>(area);
            return Ok(data);
        }

        [HttpGet(ApiRoute.Master.City)]
        public async Task<IActionResult> GetCityAsync()
        {
            var city = await _appRespiratory.GetCityAsync();
            var data = _mapper.Map<IEnumerable<CityDto>>(city);
            return Ok(data);
        }
    }
}
