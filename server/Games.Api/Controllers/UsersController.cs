using AutoMapper;
using Games.Core;
using Games.Core.service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Games.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;

        }
        //פונקציה אסינכרונית
        // GET: api/<UsetsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var users = mapper.Map<IEnumerable<UserDTO>>(await userService.getAll());
            if (users != null) return Ok(users);
            return NotFound();
        }

        // GET api/<UsetsController>/5
        [HttpGet("{id}")]
        public UserDTO Get(int id)
        {
            var user = mapper.Map<UserDTO>(userService.getById(id));
            return user;
        }

        [HttpPost("GetByUserNameAndPassword")]
        public ActionResult< UserDTO> Get([FromBody] LoginRequest loginRequest)
        {
            var user =  mapper.Map<UserDTO>(userService.getByUserNameAndPassword(loginRequest.Name, loginRequest.Password));
            if (user == null) return StatusCode(404);
            return Ok(user);
        }
        // POST api/<UsetsController>
        [HttpPost]
        public ActionResult Post([FromBody] UserDTO user)
        {
            userService.addUser(mapper.Map<User>(user));
            return Ok();
        }

        // PUT api/<UsetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO user)
        {
            user.Id = id;
            userService.updateUser(mapper.Map<User>(user));

        }

        // DELETE api/<UsetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userService.removeUser(id);
        }
    }
}
