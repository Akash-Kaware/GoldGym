namespace GoldGym.Data
{
    using Dapper;
    using GoldGym.Models;
    using System.Data;
    using System.Data.SqlClient;

    public class SqlDbConnection
    {
        private readonly string _connectionString;
        public SqlDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection CreateSqlConnection() => new SqlConnection(_connectionString);

        public async Task<SqlConnection> GetOpenSqlConnectionAsync()
        {
            SqlConnection conn = CreateSqlConnection();
            await conn.OpenAsync();
            return conn;
        }

        public async Task<IList<T>> GetAll<T>(string query,
            CommandType commandType = CommandType.StoredProcedure)
        {
            using var conn = await GetOpenSqlConnectionAsync();
            var list = await SqlMapper.QueryAsync<T>(conn, query, commandType: commandType);
            conn.Close();
            return list.ToList();
        }

        public async Task<IList<T>> GetById<T>(string query, DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using var conn = await GetOpenSqlConnectionAsync();
                var row = await SqlMapper.QueryAsync<T>(conn, query, parameters, commandType: commandType);
                conn.Close();
                return row.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ExecuteQueryAsync(string query, DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using var conn = await GetOpenSqlConnectionAsync();
                int result = await conn.ExecuteAsync(query, parameters, commandType: commandType);
                conn.Close();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<(List<T>, List<S>)> ExecuteMultipleAsync<T, S>(string query, DynamicParameters parameters,
            CommandType commandType = CommandType.StoredProcedure)
        {
            try
            {
                using var conn = CreateSqlConnection();
                var result = await SqlMapper.QueryMultipleAsync(conn, query, parameters, commandType: commandType);
                var TList = await result.ReadAsync<T>();
                var SList = await result.ReadAsync<S>();
                return (TList.ToList(), SList.ToList());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
