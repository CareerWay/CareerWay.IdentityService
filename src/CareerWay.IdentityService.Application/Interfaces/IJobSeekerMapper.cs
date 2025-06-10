using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Entities;

namespace CareerWay.IdentityService.Application.Interfaces;

public interface IJobSeekerMapper
{
    JobSeeker Map(CreateJobSeekerRequest request, JobSeeker jobSeeker);
}
