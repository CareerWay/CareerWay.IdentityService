using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Entities;

namespace CareerWay.IdentityService.Application.Interfaces;

public interface ICompanyMapper
{
    CompanyDetailResponse Map(Company company, CompanyDetailResponse response);

    Company Map(CreateCompanyRequest request, Company company);

    EditCompanyResponse Map(Company company, EditCompanyResponse response);

    Company Map(EditCompanyRequest request, Company company);
}
