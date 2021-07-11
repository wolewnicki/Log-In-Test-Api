using auth_api.Entities;

namespace auth_api.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void Save();
    }
}
