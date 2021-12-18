using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    //creating this Dto to prevent circular exceptions whe we getting 
    //photos collection for user

    public class MembersDto
    {
        //copying all properties from user and pasting inside the
        //class(except methods)
        public int Id { get; set; }
        public string Username { get; set; }
       /* public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }*/
        /*adding new properties*/
        /*public DateTime DateOfBirth { get; set; }
        instead of this property we will enter user Age*/


        //adding user main photo prop
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public string KnownAS { get; set; }//nickname
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Gender { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
       /* public ICollection<Photo> Photos { get; set; }
       instead of creating  type photo that will
       bring us a problem we will use new type
       PhotoDto*/
       public ICollection <PhotoDto> Photos { get; set; }
        
    }
}