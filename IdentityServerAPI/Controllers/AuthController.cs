using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace IdentityServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        [Route("Value")]
        public async Task<IActionResult> GetValue()
        {
            IList<Claim> claims = new List<Claim>()
            {
                new Claim("sub", "1")
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)));
                
            return Ok("Hello");
        }

        [HttpGet]
        [Authorize]
        [Route("Secret")]
        public async Task<IActionResult> GetSecret()
        {
            return Ok("Hello");
        }
    }
}
