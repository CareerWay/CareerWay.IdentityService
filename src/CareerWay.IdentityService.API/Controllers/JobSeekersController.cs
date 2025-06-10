using Asp.Versioning;
using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CareerWay.IdentityService.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1)]
public class JobSeekersController : ControllerBase
{
    private readonly IJobSeekerService _jobseekerService;
    public JobSeekersController(IJobSeekerService jobseekerService)
    {
        _jobseekerService = jobseekerService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateJobSeekerRequest request)
    {
        var result = await _jobseekerService.Create(request);
        return Created(string.Empty, result);
    }
}
