using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Dtos;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRespiratory _patientRespiratory;
        private readonly IMapper _mapper;

        public PatientsController(IPatientRespiratory patientRespiratory, IMapper mapper)
        {
            _patientRespiratory = patientRespiratory;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Patient.GetPatients)]
        public async Task<IActionResult> GetPatientAsync()
        {
            var patient = await _patientRespiratory.GetPatientsAsync();
            var data =  _mapper.Map<IEnumerable<PatientDto>>(patient);
            return Ok(data);

        }
    }
}
