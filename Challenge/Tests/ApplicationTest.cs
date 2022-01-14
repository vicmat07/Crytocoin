using Hahn.ApplicatonProcess.July2021.Data;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Data.Repository.IRepository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Tests
{
    public class ApplicationTest
    {
        private IUserRepository _repository;
        public ApplicationTest(IUserRepository repository)
        {
            _repository = repository;
        }
        public void Seed()
        {
            User user1 = new User { 
                                Id = 1, FirstName = "Victor", 
                                LastName = "Farias", 
                                Age = 26, 
                                Address = "Rua dona Ines, 56", 
                                Asset = null, 
                                Email = "victor.farias@bairesdev.com" };
            _repository.CreateUser(user1);
        }
    }
}
