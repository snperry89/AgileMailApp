﻿using Rockwood.Data;
using Rockwood.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rockwood.Services
{
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                        new UserListItem
                        {
                            UserId = e.UserId,
                            EmailAddress = e.EmailAddress,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                        );
                return query.ToArray();
            }
        }


    }
}
