using HealthcareSystem.Business.Abstracts;
using HealthcareSystem.Business.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var list = await _service.Getlist();

            return ControllerResult(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var list = await _service.GetById(id);

            return ControllerResult(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AppointmentDto model)
        {
            var result = await _service.Add(model);
            return ControllerResult(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(AppointmentDto model)
        {
            var result = await _service.Update(model);
            return ControllerResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ControllerResult(result);
        }
    }
}
