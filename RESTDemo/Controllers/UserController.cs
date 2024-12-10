using Microsoft .AspNetCore .Mvc;
using RESTDemo .Model;
using RESTDemo .Services;
using Microsoft .AspNetCore .Http;
using System;
using System .Collections .Generic;
using System .Linq;

namespace RESTDemo .Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
        {
        private readonly IUserService _service;

        public UserController ( IUserService service )
            {
            _service = service;
            }

        // POST api/user/register
        [HttpPost("register")]
        public IActionResult Register ( [FromBody] User user )
            {
            try
                {
                var result = _service .RegisterUser(user);
                if ( result >= 1 )
                    {
                    return StatusCode(StatusCodes .Status201Created , "User registered successfully.");
                    }
                else
                    {
                    return StatusCode(StatusCodes .Status409Conflict , "User already exists.");
                    }
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }

        // POST api/user/login
        [HttpPost("login")]
        public IActionResult Login ( [FromBody] LoginRequest loginRequest )
            {
            try
                {
                var user = _service .LoginUser(loginRequest .Email , loginRequest .Password);
                if ( user != null )
                    {
                    return Ok("Login successful.");
                    }
                else
                    {
                    return Unauthorized("Invalid email or password.");
                    }
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }

        // GET api/user/{id} - Get user by id (optional)
        [HttpGet("{id}")]
        public IActionResult GetUserById ( int id )
            {
            try
                {
                var user = _service .GetUserById(id);
                if ( user != null )
                    {
                    return Ok(user);
                    }
                else
                    {
                    return NotFound("User not found.");
                    }
                }
            catch ( Exception ex )
                {
                return StatusCode(StatusCodes .Status500InternalServerError , ex .Message);
                }
            }
        }

    // LoginRequest class for login payload
    public class LoginRequest
        {
        public string Email { get; set; }
        public string Password { get; set; }
        }
    }
