using AdvanceCSharp.dto.Users.Request;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _userService;
        public UsersController()
        {
            _userService = new UsersService();
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
                return new JsonResult(await _userService.Get(request));
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
                return new JsonResult(await _userService.GetList(request));
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
                return new JsonResult(await _userService.Create(request));
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
                return new JsonResult(await _userService.Update(request));
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
                return new JsonResult(await _userService.Delete(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
