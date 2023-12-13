using AdvanceCSharp.dto.Orders.Request;
using AdvanceCSharp.dto.Orders.Response;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _OrderService;

        public OrdersController()
        {
            _OrderService = new OrdersService();
        }

        [HttpGet]
        [Route("get-order")]
        public async Task<IActionResult> GetOrder([FromQuery] GetOrderRequest request)
        {
            try
            {
                GetOrderResponse response = await _OrderService.GetOrder(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("get-list-order")]
        public async Task<IActionResult> GetListOrder([FromQuery] GetListOrderRequest request)
        {
            try
            {
                GetListOrderResponse response = await _OrderService.GetListOrder(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder ([FromQuery] CreateOrderRequest request)
        {
            try
            {
                CreateOrderResponse response = await _OrderService.CreateOrder(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromQuery]DeleteOrderRequest request)
        {
            try
            {
                DeleteOrderResponse response = await _OrderService.DeleteOrder(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("update-order")]
        public async Task<IActionResult> UpdateOrder([FromQuery] UpdateOrderRequest request)
        {
            try
            {
                UpdateOrderResponse response = await _OrderService.UpdateOrder(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
