using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RoomBi.BLL;
using RoomBi.BLL.DTO;
using RoomBi.BLL.DTO.New;
using RoomBi.BLL.Interfaces;
using RoomBi.DAL;
using RoomBi_Server.Token;
using System.Security.Claims;

namespace RoomBi_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IServiceOfAll<UserDTO> userService, IServiceOfUser<UserDTO> serviceOfUser,
        IJwtToken jwtTokenService, IServiceOfUserGoogle<User> serviceOfUserGoogle, IServiceOfAll<UserDTOProfile> serviceProfile) : ControllerBase
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
                RefreshToken = refreshToken,
                Profile = user.Profile
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
                //var user = await serviceOfUser.GetUserByEmail(request.Email);
                //var newToken = jwtTokenService.GetToken(user);
                //var newRefreshToken = jwtTokenService.GenerateRefreshToken();
                //user.RefreshToken = newRefreshToken;
                //await userService.Update(user);
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
                                DateOfBirth = DateTime.Parse(request.DateOfBirth),
                                Country = request.Country
                            };
                            await userService.Create(user);
                            user = await serviceOfUser.GetUserByEmail(user.Email);
                            if (user.Profile != null)
                            {
                                user.PF = "Yes";
                            }
                            var response = await AuthenticateUser(user);
                            user.RefreshToken = response.RefreshToken;
                            await serviceOfUser.UpdateRefreshToken(user);
                            return Ok(response);
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    case "login":
                        try
                        {
                            UserDTO user = await serviceOfUser.GetUserByEmail(request.Email);
                            if (serviceOfUser.GetBoolByPassword(request.Password, user.Password))
                            {
                                var response = await AuthenticateUser(user);
                                user.RefreshToken = response.RefreshToken;
                                if (user.Profile != null)
                                {
                                    user.PF = "Yes";
                                }
                                await serviceOfUser.UpdateRefreshToken(user);
                                return Ok(response);
                            }
                            else
                            {
                                return BadRequest("Паролі не співпадають.");
                            }
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
                    case "google":
                        try
                        {
                            var user = await serviceOfUserGoogle.GetUserByGoogle(request);
                            var user2 = await serviceOfUser.GetUserByEmail(user.Email);
                            var response = await AuthenticateUser(user2);
                            user2.RefreshToken = response.RefreshToken;
                            if (user2.Profile != null)
                            {
                                user2.PF = "Yes";
                            }
                            await serviceOfUser.UpdateRefreshToken(user2);
                            return Ok(response);
                        }
                        catch (Exception ex)
                        {
                            return BadRequest(ex.Message);
                        }
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
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteUser()
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
        [Authorize]
        // PUT: api/users/5
        [HttpPut]
        public async Task<IActionResult> PutUser(UserDTO user)
        {   //string token = HttpContext.Request.Headers.Authorization;
            //string cleanedToken = token.Replace("Bearer ", "");
            //ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            //int temp = int.Parse(jwtTokenService.GetIdFromToken(principal));
            //if (temp != user.Id)
            //{
            //    return BadRequest();
            //}

            await userService.Update(user);
            user = await serviceOfUser.GetUserByEmail(user.Email);
            var token = jwtTokenService.GetToken(user);
            var refreshToken = user.RefreshToken;
            if (user.Profile != null)
            {
                user.PF = "Yes";
            }
            var response = new AuthenticationResponseDTO
            {
                Token = token,
                RefreshToken = refreshToken
            };
            return Ok(response);

        }


        [Authorize]
        // GET: api/users/5
        [HttpGet("email")]
        public async Task<ActionResult<UserDTO>> GetUser()
        {
            string token = HttpContext.Request.Headers.Authorization;
            string cleanedToken = token.Replace("Bearer ", "");
            ClaimsPrincipal principal = jwtTokenService.GetPrincipalFromExpiredToken(cleanedToken);
            string temp = jwtTokenService.GetMailFromToken(principal);
            var user = await serviceOfUser.GetUserByEmail(temp);
            //var user = await serviceOfUser.GetUserByEmail("jane.smith@example.com");
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTOProfile>> GetUser(int id)
        {
            var user = await serviceProfile.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }


    }
}
