using AutoMapper;
using FluentValidation;
using Hahn.ApplicatonProcess.July2021.Data.DTO;
using Hahn.ApplicatonProcess.July2021.Data.Profiles;
using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Data.Repository.IRepository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IUserRepository _repository;
        readonly CreateUserValidator _validator;
        readonly IMapper _mapper;
 
        public UsersController(IUserRepository repository, CreateUserValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        public IActionResult GetUsers()
        {
            var users = _repository.GetUsers();
            return Ok(users);

        }
        [HttpGet( "query", Name = "GetUser")]
        [Route("query")]
        public IActionResult GetUser([FromQuery] Query query)
        {
            var obj = _repository.GetUser(query);
            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUser createUser)
        {

            User user = _mapper.Map<User>(createUser);

            if (!_validator.Validate(user).IsValid)
            {
                foreach (var failure in _validator.Validate(user).Errors)
                {
                    return BadRequest(failure.ErrorMessage);
                }
            }
            _repository.CreateUser(user);
            
            return CreatedAtRoute("GetUser", new { userId = user.Id } , user);
        }
        [HttpDelete("query", Name = "DeleteUser")]
        [Route("query")]
        public IActionResult DeleteUser(Query query)
        {
            var obj = _repository.GetUser(query);
            if (obj == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(query);
            return Ok();
        }
    }
}
