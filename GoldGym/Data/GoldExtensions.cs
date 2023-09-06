using GoldGym.Models;

namespace GoldGym.Data
{
    public static class GoldExtensions
    {
        public static void DecryptPassword(this UserModel user)
        {
            user.Password = Encryption.Decrypt(user.Password);
        }

        public static void DecryptPasswords(this List<UserModel> users)
        {
            users.ForEach(user =>
            {
                user.Password = Encryption.Decrypt(user.Password);
            });
        }
    }
}
