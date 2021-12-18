using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    //adding routin
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;//generating interface field
        private readonly IMapper _mapper;//init field for mapper
        public UsersController(IUserRepository userRepository,/*injecting
        auromapper interface*/IMapper mapper)//injecting interface
        {
            _mapper = mapper;
            _userRepository = userRepository;//assigning the interface properties
        }
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<MembersDto>>> GetUsers()
        {           
            //creating the var to assign value of users from interface IUserRepository
            var users=await _userRepository.GetMembersAsync();
            /*now we want to map this users to IEnumerable<MembersDto>*/
            //var usersToReturn=_mapper.Map<IEnumerable<MembersDto>>(users);
            return Ok(users);
        }

        //api/users/lisa
      
        [HttpGet("{username}")]
        
              //public async Task<ActionResult<MembersDto>> GetUser(string username)
             //{
           //   /*creating var user to pass the value from IUserRepository interface*/
          //    var user= await _userRepository.GetUserByUserNameAsync(username);
         //    /*now we want to map and return this user to MembersDto*/
        //     return _mapper.Map<MembersDto>(user);
       // }
       /*instead of above function we will use new function using MemberDto
       from UserRepository*/
       public async Task <ActionResult <MembersDto>> GetUser(string username){
           return await _userRepository.GetMemberAsync(username);
       }
    }
}