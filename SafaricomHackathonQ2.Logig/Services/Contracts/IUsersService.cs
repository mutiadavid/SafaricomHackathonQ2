using SafaricomHackathonQ2.Logic.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafaricomHackathonQ2.Logic.Services.Contracts
{
    public interface IUsersService
    {
        Task<Guid> CreateUserAsync(CreateUserRequest user);
    }
}
