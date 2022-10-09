using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemo.Controllers
{
    /// <summary>
    /// 我的api测试接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")] //声明控制器的操作支持 application/json 的响应内容类型
    public class MyController : ControllerBase
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns>数组字符串</returns>
        /// <remarks>
        /// Sample request(请求样例):
        ///
        ///     GET /api/My
        ///     {
        ///        
        ///     }
        ///
        /// </remarks>
        /// <response code="201">返回码：201</response>
        /// <response code="400">返回码：400</response>
        // GET: api/My
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)] //描述响应类型
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/My/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="value"></param>
        // POST: api/My
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/My/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
