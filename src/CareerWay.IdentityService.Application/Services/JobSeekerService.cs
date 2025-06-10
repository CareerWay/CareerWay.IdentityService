using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Constants;
using CareerWay.IdentityService.Domain.Entities;
using CareerWay.IdentityService.Domain.Localization;
using CareerWay.Shared.Core.Exceptions;
using CareerWay.Shared.Security.Tokens;
using CareerWay.Shared.TimeProviders;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace CareerWay.IdentityService.Application.Services;

public class JobSeekerService : IJobSeekerService
{
    private readonly IJobSeekerMapper _jobSeekerMapper;
    private readonly UserManager<JobSeeker> _jobSeekerManager;
    private readonly IDateTime _dateTime;
    private readonly IStringLocalizer<IdentityServiceResource> _stringLocalizer;
    private readonly ITokenService _tokenService;

    public JobSeekerService(
        IJobSeekerMapper jobSeekerMapper,
        UserManager<JobSeeker> jobSeekerManager,
        IDateTime dateTime,
        IStringLocalizer<IdentityServiceResource> stringLocalizer,
        ITokenService tokenService)
    {
        _jobSeekerMapper = jobSeekerMapper;
        _jobSeekerManager = jobSeekerManager;
        _dateTime = dateTime;
        _stringLocalizer = stringLocalizer;
        _tokenService = tokenService;
    }

    public async Task<CreateJobSeekerResponse> Create(CreateJobSeekerRequest request)
    {
        var jobSeeker = await _jobSeekerManager.FindByEmailAsync(request.Email);
        if (jobSeeker == null)
        {
            jobSeeker = new JobSeeker();
        }
        else
        {
            throw new BusinessException(_stringLocalizer["UserExistsByEmail"]);
        }

        _jobSeekerMapper.Map(request, jobSeeker);
        jobSeeker.CreationDate = _dateTime.Now;
        jobSeeker.LastLoginDate = _dateTime.Now;

        var createJobSeekeresult = await _jobSeekerManager.CreateAsync(jobSeeker, request.Password);
        if (!createJobSeekeresult.Succeeded)
        {
            throw new BusinessException(createJobSeekeresult.Errors.First().Description);
        }

        var addToRoleResult = await _jobSeekerManager.AddToRolesAsync(jobSeeker, [RoleConsts.JobSeeker]);
        if (!addToRoleResult.Succeeded)
        {
            throw new BusinessException(createJobSeekeresult.Errors.First().Description);
        }

        var accessToken = _tokenService.CreateAccessToken(new AccessTokenClaims()
        {
            UserId = jobSeeker.Id,
            Email = jobSeeker.Email,
            PhoneNumber = jobSeeker.PhoneNumber,
            Roles = (await _jobSeekerManager.GetRolesAsync(jobSeeker)).ToArray()
        });

        return new CreateJobSeekerResponse()
        {
            AccessToken = accessToken
        };
    }
}
