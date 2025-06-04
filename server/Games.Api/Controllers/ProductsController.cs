using AutoMapper;
using Games.Core;
using Games.Core.service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductsController(IProductService _productService, IMapper _mapper)
        {
            productService = _productService;
            mapper = _mapper;

        }



        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            var products = productService.getAll();
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            var product = productService.getById(id);
            return mapper.Map<ProductDTO>(product);
        }

        // GET api/<ProductsController>/CategoryId
        [HttpGet("CategoryId/{id}")]
        public IEnumerable<ProductDTO> GetByCategory(int id)
        {
            var products = productService.getByCategory(id);
            return mapper.Map<IEnumerable<ProductDTO>>(products);
        }
        // GET api/<ProductsController>/GetFinished
        [HttpGet("GetFinished")]
        [Authorize]
        //לשימוש מנהל בלבד 
        public List<ProductDTO> GetFinished()
        {
            var products = productService.getfinished();
            return mapper.Map<List<ProductDTO>>(products);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Post([FromBody] ProductDTO productDto)
        {
            var product = mapper.Map<Product>(productDto);
            productService.addProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Put(int id, [FromBody] ProductDTO productDto)
        {
            var product = mapper.Map<Product>(productDto);
            product.Id = id;
            productService.updateProduct(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Delete(int id)
        {
            productService.removeProduct(id);
        }
    }
}
