using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context,ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }
        [HttpPost("register")]
        public async Task< ActionResult<UserDto>> Register(RegisterDto regDto)
        {
            if(await UserExist(regDto.Username)){
                return  BadRequest("Username is taken");
            }
            using var hmac=new HMACSHA512();
            var user=new AppUser{
                UserName=regDto.Username.ToLower(),
                PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(regDto.Password)),
                PasswordSalt=hmac.Key
            };
            _context.USers.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto{
                Username=user.UserName,
                Token=_tokenService.CreateToken(user)  
            };
            
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto loginDTO){
            var loginUser=await _context.USers
                .SingleOrDefaultAsync(x=>x.UserName==loginDTO.Username);//searching for user name
                                                                    
            if(loginUser==null)return Unauthorized("Invalid user name");//if its not exist=>unauthorized exception
            //now if we pass through the username search, we want to check if the password is valid
            using var hmac=new HMACSHA512(loginUser.PasswordSalt);//here we creating the
                                                                //salt key to decrypte the hash password
                                                            //and to check it with original string password
            var computedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));//getting user password string
            //so from password salt in db we compitig password hash that will compute our password string
            //because its a byte array we need to loop over each byte
            for(int i=0;i<computedHash.Length;i++)
            {//checking if the hash is equal to db hash
                if(computedHash[i]!=loginUser.PasswordHash[i])return Unauthorized("the password didnt match");

            }
           
           //if evrething is ok we will return the loginUser
            return new UserDto{
                Username=loginUser.UserName,
                Token=_tokenService.CreateToken(loginUser)
            };
        }
         public async Task<bool> UserExist(string usename)
         {
             return await _context.USers.AnyAsync(x=>x.UserName==usename.ToLower());
         }
    }
}