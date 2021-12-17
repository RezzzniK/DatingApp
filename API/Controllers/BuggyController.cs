using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {   //init _context variable
        private readonly DataContext _context;
        //init constructor
        public BuggyController(DataContext context)
        {
            _context=context;
        }
        //generating methods that will bring us diffrent kind of error responses
        [Authorize] //to enter this methods user will require to authinticate
        [HttpGet("auth")]//localhost:5001/api/buggy/auth
        public ActionResult <string> GetSecret(){
            return "secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser/*because we returning User object*/> GetNotFound(){
            var thing=_context.USers.Find(-1);
            if(thing==null)return NotFound();//create not found response(404) built in function
            return Ok(thing);//create response (200=OK) with object info(built in function)
        }
        [HttpGet("server-error")]
        public ActionResult <string> GetServerError(){
            var thing=_context.USers.Find(-1);//returning null in case if object not found by given primary key
            var thingToReturn=thing.ToString();//we using function .ToString, because when 
                                              // when we trying to make a string from null
                                              //we will get the null reference exception
            return thingToReturn;//will pass null reference exception
        }
        [HttpGet("bad-request")]
        public ActionResult<string>GetBadRequest(){
            return BadRequest("this is not a good request-its literally bad one");
        }
    }
}