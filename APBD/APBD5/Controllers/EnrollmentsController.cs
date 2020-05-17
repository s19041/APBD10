﻿using APBD5.Helpers;
using APBD5.DTOs.RequestModels;
using APBD5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APBD5.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        [ApiController]
        [Route("api/enrollments")]
        public class EnrollmentsController : Controller
        {
            private readonly IStudentsDbService _dbService;
            private IConfiguration Configuration;

            public EnrollmentsController(IStudentsDbService iStudentsDbService, IConfiguration iConfiguration)
            {
                _dbService = iStudentsDbService;
                Configuration = iConfiguration;
            }


            [HttpPost]
            [Authorize(Roles = "employee")]
            public IActionResult EnrollStudent(EnrollStudentRequest request)
            {
                try
                {
                    return Ok(_dbService.EnrollStudent(request));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            [HttpPost("promotions")]
            [Authorize(Roles = "employee")]
            public IActionResult PromoteStudent(PromoteStudentRequest request)
            {
                try
                {
                    return Ok(_dbService.PromoteStudents(request));
                }
                catch (Exception e)
                {
                    return NotFound(e.Message);
                }
            }

            [HttpGet("login")]
            public IActionResult Login(LoginRequest loginRequest)
            {
                if (!_dbService.CheckPassword(loginRequest))
                {
                    return Forbid("Bearer");
                }

                var claims = _dbService.GetClaims(loginRequest.Index);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Gakko",
                    audience: "Students",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds
                );
                var refreshToken = Guid.NewGuid();
                _dbService.SetRefreshToken(loginRequest.Index, refreshToken.ToString());
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), refreshToken });
            }

            [HttpPost("token/{token}")]
            public IActionResult RefreshToken(string token)
            {
                var user = _dbService.CheckRefreshToken(token);
                if (user == null)
                {
                    return Forbid("Bearer");
                }

                var claims = _dbService.GetClaims(user);
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var newToken = new JwtSecurityToken(
                    issuer: "Gakko",
                    audience: "Students",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: creds
                );
                var refreshToken = Guid.NewGuid();
                _dbService.SetRefreshToken(user, refreshToken.ToString());
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(newToken), refreshToken });
            }
            [HttpPost("password")]
            [Authorize]
            public IActionResult SetPassword(ChangePasswordRequest request)
            {
                var index = User.Claims.ToList()[0].ToString().Split(": ")[1];
                _dbService.SetPassword(index, request.NewPassword);
                return Ok("Password has been changed");
            }
        }
    }