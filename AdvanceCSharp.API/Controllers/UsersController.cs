using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _UserService;
        public UsersController()
        {
            _UserService = new UsersService();
        }
        /// <summary>
        /// HTTP GET
        /// </summary>
        [Route("get-profile")]
        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] GetUserRequest request)
        {
            try
            {
                return new JsonResult(await _UserService.GetById(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP GET (List)
        /// </summary>
        [Route("get-list-profile")]
        [HttpGet]
        public async Task<IActionResult> GetListUser([FromQuery] GetListUserRequest request)
        {
            try
            {
                return new JsonResult(await _UserService.GetList(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP POST
        /// </summary>
        [Route("post-new-user")]
        [HttpPost]
        public async Task<IActionResult> PostNewUser([FromQuery] NewUserRequest request)
        {
            try
            {
                return new JsonResult(await _UserService.CreateUser(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP PUT
        /// </summary>
        [Route("update-user-profile")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery] UpdateUserRequest request)
        {
            try
            {
                return new JsonResult(await _UserService.UpdateUser(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP DELETE
        /// </summary>
        [Route("delete-user-profile")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserRequest request)
        {
            try
            {
                return new JsonResult(await _UserService.DeleteUser(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
