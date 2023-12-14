﻿using AdvanceCSharp.dto.Products.Request;
using AdvanceCSharp.dto.Products.Response;
using AdvanceCSharp.service;
using Microsoft.AspNetCore.Mvc;

namespace AdvanceCSharp.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _ProductService;

        public ProductsController()
        {
            _ProductService = new ProductsService();
        }

        [HttpGet]
        [Route("get-product")]
        public async Task<IActionResult> GetProduct([FromQuery]GetProductRequest request)
        {
            try
            {
                return new JsonResult(await ProductsService.GetProduct(request));
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpGet]
        [Route("get-list-product")]
        public async Task<IActionResult> GetListProduct([FromQuery]GetListProductRequest request)
        {
            try
            {
                GetListProductResponse response = await ProductsService.GetListProduct(request);
                return new JsonResult(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("update-product")]
        public async Task<IActionResult> UpdateProduct([FromQuery]UpdateProductRequest request)
        {
            try
            {
                return new JsonResult(await ProductsService.UpdateProduct(request));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("create-product")]
        public async Task<IActionResult> CreateProduct([FromQuery]CreateProductRequest request)
        {
            try
            {
                return new JsonResult(await ProductsService.CreateProduct(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
       [HttpDelete]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductRequest request)
        {
            try
            {
                return new JsonResult(await ProductsService.DeleteProduct(request));
            }
            catch( Exception ex) 
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
