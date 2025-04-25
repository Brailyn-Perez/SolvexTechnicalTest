using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SolvexTechnicalTest.Core.Application.DTOs.Users;
using SolvexTechnicalTest.Core.Application.Enums;
using SolvexTechnicalTest.Core.Application.Exceptions;
using SolvexTechnicalTest.Core.Application.Interfaces.Identity;
using SolvexTechnicalTest.Core.Application.Wrappers;
using SolvexTechnicalTest.Core.Domain.Settings;
using SolvexTechnicalTest.Infraestructe.Identity.Entities;
using SolvexTechnicalTest.Infraestructe.Identity.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SolvexTechnicalTest.Infraestructe.Identity.Service
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JWTSettings _jwtSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, JWTSettings jwtsetting)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtSettings = jwtsetting;
        }


        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"user not found {request.Email}");
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateJWTToken(user);

            AuthenticationResponse response = new AuthenticationResponse();

            response.Id = int.TryParse(user.Id, out var userId) ? userId : 0; 
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;

            var rolesList = await _userManager.GetRolesAsync(user);
            response.Roles = rolesList.ToList();

            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(ipAddress);

            response.RefreshToken = refreshToken.Token;
            return new Response<AuthenticationResponse>(response, $"{user.UserName}");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userWhitTheSameUserName = await _userManager.FindByNameAsync(request.Name);

            if (userWhitTheSameUserName != null)
                throw new ApiException($"");

            var user = new ApplicationUser
            {
                Email = request.Email,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userWhitTheSameEmail = await _userManager.FindByEmailAsync(request.Email);

            if (userWhitTheSameEmail != null)
                throw new ApiException($"");
            else
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    return new Response<string>(user.Id, message: $"User created {request.UserName}");
                }
                else
                {
                    throw new ApiException($"{result.Errors}");
                }
            }


            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateJWTToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip",ipAddress),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;

        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");

        }
    }

}
