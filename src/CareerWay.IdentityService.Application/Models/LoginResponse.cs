using CareerWay.Shared.Security.Tokens;
using Microsoft.AspNetCore.Identity;

namespace CareerWay.IdentityService.Application.Models;

public class LoginResponse
{
    public bool Succeeded { get; set; }

    public bool Failed { get; set; }

    public bool IsLockedOut { get; set; }

    public bool RequiresTwoFactor { get; set; }

    public bool RequiresEmailConfirmation { get; set; }

    public AccessToken? AccessToken { get; set; }

    private LoginResponse()
    {
    }

    public static LoginResponse Success(AccessToken accessToken)
    {
        return new LoginResponse() { Succeeded = true, AccessToken = accessToken };
    }

    public static LoginResponse Fail()
    {
        return new LoginResponse() { Failed = true };
    }

    public static LoginResponse LockedOut()
    {
        return new LoginResponse() { IsLockedOut = true };
    }

    public static LoginResponse TwoFactorRequired()
    {
        return new LoginResponse() { RequiresTwoFactor = true };
    }

    public static LoginResponse EmailConfirmationRequired()
    {
        return new LoginResponse() { RequiresEmailConfirmation = true };
    }

    public static explicit operator LoginResponse(SignInResult signInResult)
    {
        if (signInResult.Succeeded)
        {
            return new LoginResponse() { Succeeded = true };
        }
        else if (signInResult.IsNotAllowed)
        {
            return EmailConfirmationRequired();
        }
        else if (signInResult.IsLockedOut)
        {
            return LockedOut();
        }
        else if (signInResult.RequiresTwoFactor)
        {
            return TwoFactorRequired();
        }
        else
        {
            return Fail();
        }
    }
}
