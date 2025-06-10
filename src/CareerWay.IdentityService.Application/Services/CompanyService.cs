using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;
using CareerWay.IdentityService.Domain.Localization;
using CareerWay.Shared.Core.Exceptions;
using CareerWay.Shared.TimeProviders;
using IdGen;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CareerWay.IdentityService.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyMapper _companyMapper;
    private readonly UserManager<Company> _companyManager;
    private readonly IDateTime _dateTime;
    private readonly IStringLocalizer<IdentityServiceResource> _stringLocalizer;

    public CompanyService(
        ICompanyMapper companyMapper,
        UserManager<Company> companyManager,
        IDateTime dateTime,
        IStringLocalizer<IdentityServiceResource> stringLocalizer)
    {
        _companyMapper = companyMapper;
        _companyManager = companyManager;
        _dateTime = dateTime;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<CompanyDetailResponse> GetCompanyDetail(Guid id)
    {
        var company = await _companyManager.FindByIdAsync(id.ToString());
        if (company == null)
        {
            throw new NotFoundException();
        }

        return _companyMapper.Map(company, new CompanyDetailResponse());
    }

    public async Task<CreateCompanyResponse> Create(CreateCompanyRequest request)
    {
        var company = await _companyManager.FindByEmailAsync(request.Email);
        if (company == null)
        {
            company = new Company();
        }
        else
        {
            throw new BusinessException(_stringLocalizer["UserExistsByEmail"]);
        }

        _companyMapper.Map(request, company);
        company.CreationDate = _dateTime.Now;

        var createCompanyResult = await _companyManager.CreateAsync(company, request.Password);
        if (!createCompanyResult.Succeeded)
        {
            throw new BusinessException(createCompanyResult.Errors.First().Description);
        }

        var addToRoleResult = await _companyManager.AddToRolesAsync(company, new[] { RoleConsts.Company });
        if (!addToRoleResult.Succeeded)
        {
            throw new BusinessException(addToRoleResult.Errors.First().Description);
        }

        return new CreateCompanyResponse();
    }

    public async Task<EditCompanyResponse> Edit(EditCompanyRequest request)
    {
        var company = await _companyManager.FindByIdAsync(request.Id.ToString());
        if (company == null)
        {
            throw new NotFoundException();
        }

        _companyMapper.Map(request, company);

        var editCompanyResult = await _companyManager.UpdateAsync(company);
        if (!editCompanyResult.Succeeded)
        {
            throw new BusinessException(editCompanyResult.Errors.First().Description);
        }

        return _companyMapper.Map(company, new EditCompanyResponse());
    }
}
