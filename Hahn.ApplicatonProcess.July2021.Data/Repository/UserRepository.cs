using Hahn.ApplicatonProcess.July2021.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System.Linq;
using Hahn.ApplicatonProcess.July2021.Data.DTO;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(Query query)
        {
            User user = null;
            if (_context.Users.Any(u => u.Id == query.Id || u.Email == query.Email))
            {
                user = _context.Users.First(u => u.Id == query.Id || u.Email == query.Email);
                _context.Remove(user);
            }
            
            return Save();
        }

        public User GetUser(Query query)
        {
            IQueryable<User> users = _context.Users;
            User user = null;
            if (users.Any(u => u.Id == query.Id || u.Email == query.Email))
            {
                user = users.First(u => u.Id == query.Id || u.Email == query.Email);
                Save();
            }
            return user;
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0 ? true : false;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}
