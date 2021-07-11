using auth_api.Data;
using auth_api.Entities;

namespace auth_api.Repositories
{
    public class UserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void AddUser(UserEntity user) {
            _dataContext.Add(user);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}