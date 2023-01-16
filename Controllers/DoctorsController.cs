using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Dtos;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Doctor.GetDoctors)]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            var doctor = await _doctorService.GetDoctorsAsync();
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
