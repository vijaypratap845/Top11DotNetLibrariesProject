﻿using System.Data;
using System.Data.SqlClient;

namespace Top10LibrariesSampleProject.DAL.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DBConnectionString");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
