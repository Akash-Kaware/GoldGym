namespace GoldGym.Repository
{
    using GoldGym.Models;

    public interface IUserRepository
    {
        Task<IList<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task<UserModel?> GetUserByEmail(string email, Guid id);
        Task<bool> CreateUser(UserModel user);
        Task<bool> UpdateUser(UserModel user);
        Task<bool> DeleteUser(Guid id, Guid userId);
        Task<UserModel?> ValidateUserDetails(string email, string password);
    }
}
