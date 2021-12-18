using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    //is implementig IUserRepository
    public class UserRepository : IUserRepository
    {
      
        /*because we will be using dbcontext so we will need to create a constructor in
        order to inject datacontext inside*/
        /*also we need _context to use this in methods*/
         private readonly DataContext _context;
        private readonly IMapper _mapper;

         public UserRepository(DataContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context=context;
        }

      
        public Task<MembersDto> GetMemberAsync(string username)
        {
            /*here instead of using automapper we can use 
            linq queries*/
            return _context.USers.Where(name=>name.UserName==username)
            .ProjectTo<MembersDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MembersDto>> GetMembersAsync()
        {
            return await _context.USers.ProjectTo<MembersDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        /*now we going to implement logic inside this methods*/
        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.USers.FindAsync(id);/*when we looking by
            primary key, we using FIND built in function*/
        }


        public async Task<AppUser> GetUserByUserNameAsync(string username)
        {
            return await _context.USers.Include(x=>x.Photos/*getting photos by id but also 
            it will gives us circular reference exception
            because in photos we have our User Entitie
            and user entity have a photo collectio ..etc*/).SingleOrDefaultAsync(x=>x.UserName==username);/*
            when we looking for properties that is  not primary key,
            we using SingleOrDefault function */
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
           return await _context.USers.Include(x=>x.Photos).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _context.SaveChangesAsync()>0;/*because the function will return
           quantity of changes  in int we will logical  check 
           changes*/
        }

        public void Update(AppUser user)//this function doesn't return value
        {        /*the behavior of this function is to tell 
            entity frame    work to update th data after the changes that we 
            have made*/
           _context.Entry(user).State=EntityState.Modified;
        }
    }
}