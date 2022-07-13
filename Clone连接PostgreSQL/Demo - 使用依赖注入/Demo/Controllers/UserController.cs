using Chloe;
using Chloe.PostgreSQL;
using Demo.Service;
using Demo.Service.impl;
using Demo.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDbContext _dbContext;

        public UserController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        public Result Get()
        {
            IUserService userService = new UserServiceImpl(_dbContext);
            return userService.GetAllUser();
        }

        //// GET: api/User
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] JObject value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
