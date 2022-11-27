using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeCare_Api.Contracts;
using WeCare_Api.Dtos;
using WeCare_Api.Modals;
using WeCare_Api.Services;

namespace WeCare_Api.Controllers
{
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoute.Patient.GetPatients)]
        public async Task<IActionResult> GetPatientAsync()
        {
            var patient = await _patientService.GetPatientsAsync();
            var data =  _mapper.Map<IEnumerable<PatientDto>>(patient);
            return Ok(data);

        }
    }
}
