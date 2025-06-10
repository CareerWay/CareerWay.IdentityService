using CareerWay.IdentityService.Application.Interfaces;
using CareerWay.IdentityService.Application.Models;
using CareerWay.IdentityService.Domain.Entities;
using CareerWay.Shared.Core.Exceptions;
using CareerWay.Shared.Guids;
using CareerWay.Shared.Security.Tokens;
using CareerWay.Shared.TimeProviders;
using Microsoft.AspNetCore.Identity;

namespace CareerWay.IdentityService.Application.Services;

public class LoginService : ILoginService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public LoginService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return LoginResponse.Fail();
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
        if (signInResult.Succeeded)
        {
            var accessToken = _tokenService.CreateAccessToken(new AccessTokenClaims()
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Roles = (await _userManager.GetRolesAsync(user)).ToArray()
            });
            return LoginResponse.Success(accessToken);
        }

        return (LoginResponse)signInResult;
    }
}
