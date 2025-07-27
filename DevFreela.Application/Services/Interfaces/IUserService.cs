using DevFreela.Core.Entities;
using System.Collections.Generic;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

    }
}
