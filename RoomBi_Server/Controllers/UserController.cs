using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RoomBi.BLL.DTO;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi_Server.Token;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IServiceOfAll<UserDTO> userService, IServiceOfUser<UserDTO> serviceOfUser,
        IJwtToken jwtTokenService) : ControllerBase
    {
        [HttpPost]
        public async Task<AuthenticationResponseDTO> AuthenticateUser(UserDTO user)
        {
            var token = jwtTokenService.GetToken(user);
            var refreshToken = jwtTokenService.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            //await serviceOfUser.UpdateRefreshToken(user);
            var response = new AuthenticationResponseDTO
            {
                Token = token,
                RefreshToken = refreshToken
            };

            return response;
        }

        // POST: api/users
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> RegisterUser([FromBody] RequestUser request)
        {
            try
            {
                //UserDTO user = new()
                //{
                //    Email = request.Email,
                //    Id = 1
                //};
                ////var user = await serviceOfUser.GetUserByEmail(request.Email);
                //var newToken = jwtTokenService.GetToken(user);
                //var newRefreshToken = jwtTokenService.GenerateRefreshToken();
                ////user.RefreshToken = newRefreshToken;
                ////await userService.Update(user);
                //var response = new AuthenticationResponseDTO
                //{
                //    Token = newToken,
                //    RefreshToken = newRefreshToken
                //};
                //return Ok(response);



                switch (request.Type)
                {
                    case "register":
                        try
                        {
                            await serviceOfUser.GetBoolByEmail(request.Email);
                            return Ok("Ok");
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    case "register2":
                        try
                        {
                            UserDTO user = new()
                            {
                                Email = request.Email,
                                Password = request.Password,
                                Name = request.Name,
                                PhoneNumber = request.PhoneNumber,
                                DateOfBirth = request.DateOfBirth,
                                Country = request.Country
                            };
                            await userService.Create(user);
                            user = await serviceOfUser.GetUserByEmail(user.Email);
                            var response = await AuthenticateUser(user);
                            user.RefreshToken = response.RefreshToken;
                            await userService.Update(user);
                            return Ok(response);
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    //case "login":

                    //    try
                    //    {
                    //        UserDTO user = await serviceOfUser.GetUserByEmail(request.Email);
                    //        await serviceOfUser.GetBoolByPassword(user.Password);
                    //        var response = await AuthenticateUser(user);
                    //        return Ok(response);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        return BadRequest(ex.Message);
                    //    }
                    //case "google":
                    //    try
                    //    {
                    //        UserDTO user = new()
                    //        {
                    //            Email = request.Email,
                    //            Password = request.Password
                    //        };
                    //        var response = await AuthenticateUser(user);
                    //        await userService.Create(user);
                    //        return Ok(response);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        return BadRequest(ex.Message);
                    //    }
                    default:
                        return BadRequest("Invalid request type");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var token = HttpContext.Request.Headers.Authorization;

            //await userService.Delete(id);

            return Ok(token);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(AuthenticationResponseDTO authenticationResponseDTO)
        {
            var principal = jwtTokenService.GetPrincipalFromExpiredToken(authenticationResponseDTO.Token);
            var email = jwtTokenService.GetMailFromToken(principal);
            var user = await serviceOfUser.GetUserByEmail(email);
            if (user == null)
            {
                return BadRequest("Invalid token");
            }
            if (user.RefreshToken != authenticationResponseDTO.RefreshToken)
            {
                return BadRequest("Invalid token");
            }
            var newToken = jwtTokenService.GetToken(user);
            var newRefreshToken = jwtTokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await userService.Update(user);
            var response = new AuthenticationResponseDTO
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            };
            return Ok(response);
        }

















        //    // GET: api/users
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        //    {
        //        var users = await userService.GetAll();
        //        if (users == null || !users.Any())
        //        {
        //            return NotFound();
        //        }
        //        return Ok(users);
        //    }

        //    // GET: api/users/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<UserDTO>> GetUser(int id)
        //    {
        //        var user = await userService.Get(id);
        //        if (user == null)
        //        {
        //            return NotFound();
        //        }
        //        return user;
        //    }

        //    // PUT: api/users/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutUser(int id, UserDTO user)
        //    {
        //        if (id != user.Id)
        //        {
        //            return BadRequest();
        //        }
        //        await userService.Update(user);
        //        return NoContent();
        //    }

        //    //POST: api/users/login
        //    //[HttpPost("login")]
        //    //public async Task<ActionResult<UserDTO>> Login([FromBody] RequestUser request)
        //    //{
        //    //    var user = await serviceOfUser.GetByEmailAndPassword(request.Email, request.Password);
        //    //    if (user == null)
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    var token = jwtTokenService.GetToken(user);
        //    //    var refreshToken = jwtTokenService.GenerateRefreshToken();
        //    //    user.RefreshToken = refreshToken;
        //    //    //await userService.Update(user);
        //    //    var response = new AuthenticationResponseDTO
        //    //    {
        //    //        Token = token,
        //    //        RefreshToken = refreshToken
        //    //    };
        //    //    return Ok(response);

        //    //}


    }
}
