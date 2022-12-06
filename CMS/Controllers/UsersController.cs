using System;
using System.Collections.Generic;
using AutoMapper;
using CMS.Data;
using CMS.Dtos;
using CMS.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Controllers
{

    //API Endpoints
    [Route("api/users")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly ICMSRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(ICMSRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        //POST api/users
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            return Ok();
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDto>> GetAllUserIDs()
        {
            var userItems = _repository.GetAllUserIDs();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));

        }
    }
}
