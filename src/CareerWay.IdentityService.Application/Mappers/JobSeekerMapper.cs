using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Entities;

namespace CareerWay.IdentityService.Application.Mappers;

public class JobSeekerMapper : IJobSeekerMapper
{
    public JobSeeker Map(CreateJobSeekerRequest request, JobSeeker jobSeeker)
    {
        jobSeeker.FirstName = request.FirstName;
        jobSeeker.LastName = request.LastName;
        jobSeeker.Email = request.Email;
        jobSeeker.UserName = request.Email;
        return jobSeeker;
    }
}
