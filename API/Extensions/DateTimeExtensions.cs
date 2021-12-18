using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge(this DateTime dOb/*date of birth that
         we got from GetAge func in AppUser*/)
         {

             var today=DateTime.Today;
             var age=today.Year-dOb.Year;
             if(dOb.Date>today.AddYears(-age))age--;//checking if birthday already was this year
             return age;    
        }
    }
}