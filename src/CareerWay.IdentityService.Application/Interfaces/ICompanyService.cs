using CareerWay.IdentityService.Application.Models;

namespace CareerWay.IdentityService.Application.Interfaces;

public interface ICompanyService
{
    Task<CompanyDetailResponse> GetCompanyDetail(Guid id);

    Task<CreateCompanyResponse> Create(CreateCompanyRequest request);

    Task<EditCompanyResponse> Edit(EditCompanyRequest request);
}
