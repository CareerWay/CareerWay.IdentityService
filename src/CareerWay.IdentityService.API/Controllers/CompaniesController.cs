using Asp.Versioning;
using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CareerWay.IdentityService.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion(1)]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    public CompaniesController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetail([FromRoute] Guid id)
    {
        var company = await _companyService.GetCompanyDetail(id);
        return Ok(company);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompanyRequest request)
    {
        var result = await _companyService.Create(request);
        return Created(string.Empty, result);
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditCompanyRequest request)
    {
        var result = await _companyService.Edit(request);
        return Ok(result);
    }
}
