using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        //we will create signatures for methods
       /*All methods will be marked as async, 
       in the end of the signature, to mark that they are using task and asynchronus
       behavior*/
        public void Update(AppUser user); /*we want let to the users to update profile, 
                                            to do so we need to pass 
                                            the user object/s to do that*/
       
        Task <bool> SaveAllAsync(); /*we wiil create boolean async task
                                     to chek if we saved oure changes */
       
        Task <IEnumerable<AppUser>> GetUsersAsync(); //function for getting all user

        Task <AppUser> GetUserByIdAsync(int id);//func to get users by id

        Task <AppUser> GetUserByUserNameAsync(string username);//get the user by user name
        

        Task <IEnumerable<MembersDto>> GetMembersAsync();
        Task <MembersDto> GetMemberAsync(string username);
        

    }
} 