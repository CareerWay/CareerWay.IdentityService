using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;

namespace CareerWay.IdentityService.Application.Mappers;

public class CompanyMapper : ICompanyMapper
{
    public Company Map(CreateCompanyRequest request, Company company)
    {
        company.Email = request.Email;
        company.Title = request.Title;
        company.FirstName = request.FirstName;
        company.LastName = request.LastName;
        company.Landline = request.Landline;
        company.UserName = request.Email;
        return company;
    }

    public CompanyDetailResponse Map(Company company, CompanyDetailResponse response)
    {
        response.Id = company.Id;
        response.Title = company.Title;
        response.Phone = company.PhoneNumber!;
        response.Landline = company.Landline;
        response.City = company.City.Name;
        response.ProfilePhoto = company.ProfilePhoto ?? CompanyConsts.DefaultCompanyProfilePhoto;
        response.WebSite = company.WebSite;
        response.Instragram = company.Instragram;
        response.Facebook = company.Facebook;
        response.Twitter = company.Twitter;
        response.Linkedin = company.Linkedin;
        response.EstablishmentYear = company.EstablishmentYear;
        response.Description = company.Description;
        response.Address = company.Address;
        return response;
    }

    public Company Map(EditCompanyRequest request, Company company)
    {
        company.Id = request.Id;
        company.Title = request.Title;
        company.PhoneNumber = request.Phone;
        company.Landline = request.Landline;
        company.CityId = request.CityId;
        company.WebSite = request.WebSite;
        company.Instragram = request.Instragram;
        company.Facebook = request.Facebook;
        company.Twitter = request.Twitter;
        company.Linkedin = request.Linkedin;
        company.EstablishmentYear = request.EstablishmentYear;
        company.Description = request.Description;
        company.Address = request.Address;
        return company;
    }

    public EditCompanyResponse Map(Company company, EditCompanyResponse response)
    {
        response.Id = company.Id;
        response.Title = company.Title;
        response.Phone = company.PhoneNumber!;
        response.Landline = company.Landline;
        response.City = company.City.Name;
        response.ProfilePhoto = company.ProfilePhoto ?? CompanyConsts.DefaultCompanyProfilePhoto;
        response.WebSite = company.WebSite;
        response.Instragram = company.Instragram;
        response.Facebook = company.Facebook;
        response.Twitter = company.Twitter;
        response.Linkedin = company.Linkedin;
        response.EstablishmentYear = company.EstablishmentYear;
        response.Description = company.Description;
        response.Address = company.Address;
        return response;
    }
}
