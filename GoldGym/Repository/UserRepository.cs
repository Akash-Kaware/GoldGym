namespace GoldGym.Repository
{
    using Dapper;
    using GoldGym.Data;
    using GoldGym.Models;
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbConnection _connection;
        public UserRepository(SqlDbConnection connection)
        {
            _connection = connection;
        }

        public Task<bool> CreateUser(UserModel user)
        {
            var parameters = user.ToDynamicParameters();
            parameters.Add("Password", Encryption.Encrypt(user.Password));
            parameters.Add("IsActive", true);
            parameters.Add("CreatedBy", user.CreatedBy);
            return _connection.ExecuteQueryAsync("[gold].[User_Create]", parameters);
        }

        public async Task<bool> DeleteUser(Guid id, Guid userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            parameters.Add("UpdatedBy", userId);
            return await _connection.ExecuteQueryAsync("[gold].[User_Delete]", parameters);
        }

        public async Task<IList<UserModel>> GetAllUsers()
        {
            return await _connection.GetAll<UserModel>("[gold].[User_GetAll]");
        }

        public async Task<UserModel?> GetUserByEmail(string email, Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);
            parameters.Add("Id", id);
            var result = await _connection.GetById<UserModel>("[gold].[User_GetByEmail]", parameters);
            return result.FirstOrDefault();
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id);
            var result = await _connection.GetById<UserModel>("[gold].[User_GetById]", parameters);
            var model = result.FirstOrDefault();
            model.DecryptPassword();
            return model;
        }

        public async Task<bool> UpdateUser(UserModel user)
        {
            var parameters = user.ToDynamicParameters();
            parameters.Add("UpdatedBy", user.UpdatedBy);
            return await _connection.ExecuteQueryAsync("[gold].[User_Update]", parameters);
        }

        public async Task<UserModel?> ValidateUserDetails(string email, string password)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Email", email);
            parameters.Add("Password", Encryption.Encrypt(password));
            var result = await _connection.QueryAsync<UserModel>("[gold].[User_GetByEmailPassword]", parameters);
            return result.FirstOrDefault();
        }
    }
}
