using DemoUser.DAL.Entities;
using DemoUser.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoUser.DAL.Services
{
    public class UserService : IUserRepository<User>
    {
        public Guid CheckPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Guid Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
