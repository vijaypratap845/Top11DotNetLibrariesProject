using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Top10LibrariesSampleProject.DAL.Interfaces;
using Top10LibrariesSampleProject.Model;
using Top10LibrariesSampleProject.Validator;

namespace Top10LibrariesSampleProject.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public ProductController(IProduct product, ILoggerService logger, IMapper mapper)
        {
            _product = product;
            _logger = logger;
            _mapper = mapper;

        }

        /// <summary>
        /// This endpoint is used to get all products. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProduct() 
        {
            GetProduct getProduct = new GetProduct();
           
            try
            {
                _logger.LogError($"Something went wrong:");
                var result = await _product.GetAllProducts();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong: {ex}");
                return BadRequest(ex.Message);    
            }
        }

        /// <summary>
        /// This endpoin is used to add and update a product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUpdateProduct(AddUpdateProductDTO product)
        {
            var validator = new ProductValidator();
            var validationResult = await validator.ValidateAsync(product);
            try
            {
                if (validationResult != null)
                {

                    var result = await _product.AddUpdateProduct(_mapper.Map<AddUpdateProduct>(product));
                    if (result == 1)
                    {
                        return Ok("Success");
                    }
                    else
                    {
                        return BadRequest("Failed");
                    }
                    
                }
                else
                {
                    return BadRequest("Invalid Validation");
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong: {ex}");
                return BadRequest(ex.Message);
            }
        }
       
    }
}
