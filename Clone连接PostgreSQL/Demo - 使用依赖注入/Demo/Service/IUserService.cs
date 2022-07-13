using Demo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 查询所有的用户
        /// </summary>
        /// <returns></returns>
        Result GetAllUser();
    }
}
