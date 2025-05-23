using EFHomework.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFHomework.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPrescriptionService _service;

    public PatientsController(IPrescriptionService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatient(int id)
    {
        var patient = await _service.GetPatientAsync(id);
        return Ok(patient);
    }
}