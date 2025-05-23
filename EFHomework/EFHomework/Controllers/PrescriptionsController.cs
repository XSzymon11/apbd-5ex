using EFHomework.DTOs;
using EFHomework.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFHomework.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionService _service;

    public PrescriptionsController(IPrescriptionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] NewPrescriptionRequestDto request)
    {
        await _service.AddPrescriptionAsync(request);
        return Ok("Prescription added successfully");
    }
}