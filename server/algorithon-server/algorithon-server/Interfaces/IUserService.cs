using System.Collections.Generic;
using algorithon_server.Models;

namespace algorithon_server.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(string id);
    }
}