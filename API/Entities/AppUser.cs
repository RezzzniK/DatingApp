using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        /*adding new properties*/
        public DateTime DateOfBirth { get; set; }
        public string KnownAS { get; set; }//nicknaem
        public DateTime Created { get; set; }=DateTime.Now;
        public DateTime LastActive { get; set; }=DateTime.Now;
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> Photos { get; set; }


         //adding a fuction to calc age
    //we will add an extention to calc this
    // public int GetAge(){
    //     return DateOfBirth.CalculateAge();/*we getting this method from
    //                                      API.Extensions.DateTimeExtensions
    //                                      this method get value of DateOfBirth
    //                                      and passing to Extension class
    //                                      were is calculated and returned as int*/
    // }
    }
    

   
}