using Chloe;
using Chloe.PostgreSQL;
using Demo.Models;
using Demo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.impl
{
    public class UserServiceImpl : IUserService
    {
        public UserServiceImpl()
        {
        }
        /// <summary>
        /// 查询所有的用户
        /// </summary>
        /// <returns></returns>
        public Result GetAllUser()
        {
            //获取PostgreSQLContext实例,表示与数据库的会话，可用于查询和保存实体。
            PostgreSQLContext context = new Chloe.PostgreSQL.PostgreSQLContext(new PostgreSQLConnectionFactory(DBConnectionString.POSTGRE_SQL));
            try
            {//查询用户表
                IQuery<User> m_q_user = context.Query<User>();
                var mGetUser = m_q_user.OrderBy(a => a.id).ToList();
                return Result.Success(mGetUser, "查询成功"); //返回用户信息
            }
            catch (Exception ex)
            {
                return Result.Error(ex.Message, Result.ErrCode.ServerErr);
            }
            finally
            {
                context.Dispose();
            }
        }
    }
}
