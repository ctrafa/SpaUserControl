using System;
using System.Collections.Generic;
using System.Linq;
using SpaUserControl.Domain.Contracts.Repositories;
using SpaUserControl.Domain.Models;
using SpaUserControl.Infrastructure.Data;

namespace SpaUserControl.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDataContext _context;

        public UserRepository(AppDataContext context)
        {
            this._context = context;
        }

        public User Get(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }

        public User Get(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> Get(int skip, int take)
        {
            return _context.Users.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
