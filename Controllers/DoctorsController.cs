using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Dtos;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRespiratory _doctorRespiratory;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorRespiratory doctorRespiratory, IMapper mapper)
        {
            _doctorRespiratory = doctorRespiratory;
            _mapper = mapper;
        }

        [HttpPost(ApiRoute.Doctor.GetDoctors)]
        public async Task<IActionResult> GetDoctorsAsync(DoctorSerarchDto doctorSerarchDto)
        {
            var doctor = await _doctorRespiratory.GetDoctorsAsync(doctorSerarchDto);
            var data = _mapper.Map<IEnumerable<DoctorDto>>(doctor);
 
            DoctorDtoResponse doctorDtoResponse = new DoctorDtoResponse()
            {
                Data = data,
                IsSuccess = true,
                StatusCode = 200,
                ResponseMessage = "Doctors request completed successfully"
            };
            return Ok(doctorDtoResponse);
        } 
    }
}
