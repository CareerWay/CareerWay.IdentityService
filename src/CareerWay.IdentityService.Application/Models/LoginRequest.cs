﻿namespace CareerWay.IdentityService.Application.Models;

public class LoginRequest
{
    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}
