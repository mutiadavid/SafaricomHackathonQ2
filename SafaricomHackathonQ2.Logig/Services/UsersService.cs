using Microsoft.Extensions.Logging;
using SafaricomHackathonQ2.Data;
using SafaricomHackathonQ2.Data.Models;
using SafaricomHackathonQ2.Logic.Requests;
using SafaricomHackathonQ2.Logic.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafaricomHackathonQ2.Logic.Services
{
    public class UsersService : IUsersService
    {
        private readonly ILogger<UsersService> _logger;
        private readonly SafaricomContext _context;

        public UsersService(ILogger<UsersService> logger, SafaricomContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<Guid> CreateUserAsync(CreateUserRequest user)
        {
            try
            {
                var us = new User()
                {
                    Name = user.Name,
                    Balamce = user.Balamce,
                    PhoneNumber = user.PhoneNumber
                };

                _context.Users.Add(us);
                await _context.SaveChangesAsync();

                return us.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating user",ex);
                throw ex;
            }
        }
    }
}
