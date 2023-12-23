using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productsService;

        public ProductsController()
        {
            _productsService = new ProductsService();
        }
        /// <summary>
        /// HTTP GET
        /// </summary>
        [HttpGet]
        [Route("get-product")]
        public async Task<IActionResult> GetProduct([FromQuery]GetProductRequest request)
        {
            try
            {
                return new JsonResult(await _productsService.Get(request));
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message);
            }
        }
        /// <summary>
        /// HTTP GET (List)
        /// </summary>
        [HttpGet]
        [Route("get-list-product")]
        public async Task<IActionResult> GetListProduct([FromQuery]GetListProductRequest request)
        {
            try
            {
                GetListProductResponse response = await _productsService.GetList(request);
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
        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct([FromQuery]UpdateProductRequest request)
        {
            try
            {
                return new JsonResult(await _productsService.Update(request));
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
        [Route("create-product")]
        public async Task<IActionResult> CreateProduct([FromQuery]CreateProductRequest request)
        {
            try
            {
                return new JsonResult(await _productsService.Create(request));
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
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductRequest request)
        {
            try
            {
                return new JsonResult(await _productsService.Delete(request));
            }
            catch( Exception ex) 
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
