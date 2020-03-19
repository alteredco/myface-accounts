﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using MyFace.Helpers;
using MyFace.Models.Database;
using MyFace.Models.Request;

namespace MyFace.Repositories
{
    public interface IUsersRepo
    {
        User Authenticate(string username, string password);
        IEnumerable<User> Search(UserSearchRequest search);
        int Count(UserSearchRequest search);
        User GetById(int id);
        User GetByUserName(string username);
        User Create(CreateUserRequest newUser);
        User Update(int id, UpdateUserRequest update);
        void Delete(int id);
    }
    
    public class UsersRepo : IUsersRepo
    {
        private readonly MyFaceDbContext _context;
        private readonly IHashHelper _hashHelper;
        private IUsersRepo _usersRepoImplementation;

        public UsersRepo(MyFaceDbContext context, IHashHelper hashHelper)
        {
            _context = context;
            _hashHelper = hashHelper;
        }

        public User Authenticate(string username, string password, byte[] salt)
        {
            try
            {
               var user = _context.Users.SingleOrDefault(user => 
                   user.Username == username && user.HashedPassword == _hashHelper.GenerateHash(password, salt));
               return user;
            }
            catch
            {
                throw new SystemException("could not authenticate user");
            }
        }

        public IEnumerable<User> Search(UserSearchRequest search)
        {
            return _context.Users
                .Where(p => search.Search == null || 
                            (
                                p.FirstName.ToLower().Contains(search.Search) ||
                                p.LastName.ToLower().Contains(search.Search) ||
                                p.Email.ToLower().Contains(search.Search) ||
                                p.Username.ToLower().Contains(search.Search)
                            ))
                .OrderBy(u => u.Username)
                .Skip((search.Page - 1) * search.PageSize)
                .Take(search.PageSize);
        }

        public int Count(UserSearchRequest search)
        {
            return _context.Users
                .Count(p => search.Search == null || 
                            (
                                p.FirstName.ToLower().Contains(search.Search) ||
                                p.LastName.ToLower().Contains(search.Search) ||
                                p.Email.ToLower().Contains(search.Search) ||
                                p.Username.ToLower().Contains(search.Search)
                            ));
        }

        public User GetById(int id)
        {
            return _context.Users
                .Single(user => user.Id == id);
        }

        public User GetByUserName(string username)
        {
            return _context.Users
                .SingleOrDefault(user => user.Username == username);
        }

        public User Create(CreateUserRequest newUser)
        {
            var salt = _hashHelper.GenerateSalt();
            var insertResponse = _context.Users.Add(new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Username = newUser.Username,
                ProfileImageUrl = newUser.ProfileImageUrl,
                CoverImageUrl = newUser.CoverImageUrl,
                Salt = salt,
                HashedPassword = _hashHelper.GenerateHash(newUser.Password, salt)
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }

        public User Update(int id, UpdateUserRequest update)
        {
            var user = GetById(id);

            user.FirstName = update.FirstName;
            user.LastName = update.LastName;
            user.Username = update.Username;
            user.Email = update.Email;
            user.ProfileImageUrl = update.ProfileImageUrl;
            user.CoverImageUrl = update.CoverImageUrl;

            _context.Users.Update(user);
            _context.SaveChanges();

            return user;
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}