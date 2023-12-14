using AdvanceCSharp.dto.Carts.Request;
using AdvanceCSharp.dto.Carts.Response;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartsController : ControllerBase
    {
#pragma warning disable IDE0052 // Remove unread private members
        private readonly CartsService _CartService;
#pragma warning restore IDE0052 // Remove unread private members

        public CartsController()
        {
            _CartService = new CartsService();
        }

        [HttpGet]
        [Route("get-cart")]
        public async Task<IActionResult> GetCart([FromQuery] GetCartRequest request)
        {
            try
            {
                GetCartResponse response = await CartsService.GetCart(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("get-list-cart")]
        public async Task<IActionResult> GetListCart([FromQuery] GetListCartRequest request)
        {
            try
            {   
                GetListCartResponse response = await CartsService.GetListCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create-cart")]
        public async Task<IActionResult> CreateCart([FromQuery] CreateCartRequest request)
        {
            try
            {
                CreateCartResponse response = await CartsService.CreateCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPut]
        [Route("update-cart")]
        public async Task<IActionResult> UpdateCart([FromQuery] UpdateCartRequest request)
        {
            try
            {
                UpdateCartResponse response = await CartsService.UpdateCart(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete-cart")]
        public async Task<IActionResult> DeleteCart([FromQuery] DeleteCartRequest request)
        {
            try
            {
                DeleteCartResponse response = await CartsService.DeleteCart(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
