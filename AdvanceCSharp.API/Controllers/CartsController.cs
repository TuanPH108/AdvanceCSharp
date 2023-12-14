using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartsService _CartService;

        public CartsController()
        {
            _CartService = new CartsService();
        }
        /// <summary>
        /// HTTP GET
        /// </summary>
        [HttpGet]
        [Route("get-cart")]
        public async Task<IActionResult> GetCart([FromQuery] GetCartRequest request)
        {
            try
            {
                GetCartResponse response = await _CartService.GetCart(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP GET (List)
        /// </summary>
        [HttpGet]
        [Route("get-list-cart")]
        public async Task<IActionResult> GetListCart([FromQuery] GetListCartRequest request)
        {
            try
            {   
                GetListCartResponse response = await _CartService.GetListCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP POST
        /// </summary>
        [HttpPost]
        [Route("create-cart")]
        public async Task<IActionResult> CreateCart([FromQuery] CreateCartRequest request)
        {
            try
            {
                CreateCartResponse response = await _CartService.CreateCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
        /// <summary>
        /// HTTP PUT
        /// </summary>
        [HttpPut]
        [Route("update-cart")]
        public async Task<IActionResult> UpdateCart([FromQuery] UpdateCartRequest request)
        {
            try
            {
                UpdateCartResponse response = await _CartService.UpdateCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP DELETE
        /// </summary>
        [HttpDelete]
        [Route("delete-cart")]
        public async Task<IActionResult> DeleteCart([FromQuery] DeleteCartRequest request)
        {
            try
            {
                DeleteCartResponse response = await _CartService.DeleteCart(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
