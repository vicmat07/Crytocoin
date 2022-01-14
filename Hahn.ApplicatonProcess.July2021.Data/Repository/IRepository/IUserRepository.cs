using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.July2021.Data.DTO;
using Hahn.ApplicatonProcess.July2021.Domain.Models;

namespace Hahn.ApplicatonProcess.July2021.Data.Repository.IRepository
{
    public interface IUserRepository
    {
        public bool CreateUser(User user);
        public User GetUser(Query query);
        public List<User> GetUsers();
        public bool UpdateUser(User user);
        public bool DeleteUser(Query query);
        public bool Save();
    }
}
