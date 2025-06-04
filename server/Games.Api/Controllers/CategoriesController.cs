using AutoMapper;
using Games.Core;
using Games.Core.service;
using Games.Data.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Games.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService _categoryService, IMapper _mapper)
        {
            categoryService = _categoryService;   
            mapper = _mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryDTO> Get()
        {
            var categories = categoryService.getAll();
            return mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        // GET api/<CategoriesController>/5
        [HttpGet("ById/{id}")]
        public CategoryDTO Get(int id)
        {
            var category = categoryService.getById(id);
            return mapper.Map<CategoryDTO>(category);
        }
        // GET api/<CategoriesController>/"Name"
        [HttpGet("ByName/{name}")]
        public CategoryDTO Get(string name)
        {
            var category = categoryService.getByName(name);
            return mapper.Map<CategoryDTO>(category);
        }
        // POST api/<CategoriesController>
        [HttpPost]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Post([FromBody] CategoryDTO categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            categoryService.addCategory(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Put(int id, [FromBody] CategoryDTO categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            category.Id = id;
            categoryService.updateCategory(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        //לשימוש מנהל בלבד 
        public void Delete(int id)
        {
            categoryService.removeCategory(id);
        }
    }
}
