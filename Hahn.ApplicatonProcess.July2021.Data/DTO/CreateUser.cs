using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.July2021.Data.DTO
{
    public class CreateUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
