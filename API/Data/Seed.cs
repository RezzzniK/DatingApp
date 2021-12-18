using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        //CREATING NEW STATIC METHOD SO WE DON'T NEED TO CREATE INSTANCE OF OBJECT
        //FOR THIS
        public static async Task SeedUsers(DataContext context){
            /*checking if there is user in db*/
            if(await context.USers.AnyAsync())return;
            /*if there is no users inside we proceed to getiing .json file*/
            var userData= await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            /*now we converting from json to object*/
            var users=JsonSerializer.Deserialize<List<AppUser>>(userData);
            /*after converting we should have normal list of users of type AppUser inside*/
            /*now we will pass throug each user and will add them password Hash and salt
            and will save each user in db*/
            foreach (var user in users)
            {
                using var hmac=new HMACSHA512();//CREATING HASH GENARATOR
                user.UserName=user.UserName.ToLower();//converting name to lower case
                /*generating password and conerting to hash*/
                user.PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                /*generating salt for password(key to encrypt/decrypt password)*/
                user.PasswordSalt=hmac.Key;
                
                //adding user to array for saving in db
                context.USers.Add(user);


                
            }
            await context.SaveChangesAsync(); //saving changes to db
        }
    }
}