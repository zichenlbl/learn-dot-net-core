using Chloe.Infrastructure;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    /// <summary>
    /// PostgreSQL连接DbContext
    /// </summary>
    public class PostgreSQLConnectionFactory : IDbConnectionFactory
    {
        string _connString = "";
        public PostgreSQLConnectionFactory(string connString)
        {
            this._connString = connString;
        }
        public IDbConnection CreateConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(this._connString);
            return conn;
        }
    }
}
