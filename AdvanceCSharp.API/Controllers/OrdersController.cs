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
        private readonly OrdersService _orderService;

        public OrdersController()
        {
            _orderService = new OrdersService();
        }
        /// <summary>
        /// HTTP GET
        /// </summary>
        [HttpGet]
        [Route("get-order")]
        public async Task<IActionResult> GetOrder([FromQuery] GetOrderRequest request)
        {
            try
            {
                GetOrderResponse response = await _orderService.Get(request);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP GET (List)
        /// </summary>
        [HttpGet]
        [Route("get-list-order")]
        public async Task<IActionResult> GetListOrder([FromQuery] GetListOrderRequest request)
        {
            try
            {
                GetListOrderResponse response = await _orderService.GetList(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP POST
        /// </summary>
        [HttpPost]
        [Route("create-order")]
        public async Task<IActionResult> CreateOrder ([FromQuery] CreateOrderRequest request)
        {
            try
            {
                CreateOrderResponse response = await _orderService.Create(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP DELETE
        /// </summary>
        [HttpPut]
        [Route("delete-order")]
        public async Task<IActionResult> DeleteOrder([FromQuery]DeleteOrderRequest request)
        {
            try
            {
                DeleteOrderResponse response = await _orderService.Delete(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// HTTP PUT
        /// </summary>
        [HttpDelete]
        [Route("update-order")]
        public async Task<IActionResult> UpdateOrder([FromQuery] UpdateOrderRequest request)
        {
            try
            {
                UpdateOrderResponse response = await _orderService.Update(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
