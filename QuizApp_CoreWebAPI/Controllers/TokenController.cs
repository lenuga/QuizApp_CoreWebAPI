﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp_CoreWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp_CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly OnlineQuizDBContext _context;

        public TokenController(IConfiguration config, OnlineQuizDBContext context)
        {
            _configuration = config;
            _context = context;
        }

       [HttpPost]
       [Route("login")]
        public async Task<IActionResult> Post(LoginInfo _userData)
        {

            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Username, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("UserType", user.UserType),
                    new Claim("Password", user.Password)

                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));    

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
                    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { data = jwt_token });

                    var stream = "[encoded jwt]";
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(stream);
                    var tokenS = handler.ReadToken(stream) as JwtSecurityToken;
                    var jti = tokenS.Claims.First(claim => claim.Type == "jti").Value;

                  /*  var result = await HTTPRequest.PostAsyncResponse(URL, Params)
var token = JToken.Parse(result);
var data= token.Value<JArray>("data");*/
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserInfo> GetUser(string username, string password)
        {
            return await _context.UserInfo.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

        }
    }
}
