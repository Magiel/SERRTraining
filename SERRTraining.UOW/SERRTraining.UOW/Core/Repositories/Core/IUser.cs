using Entities.Core;
using Entities.Lookup;
using System.Collections.Generic;

namespace SERRTraining.UOW.Core.Repositories.Core
{
    public interface IUser : IRepository<User>
    {
        int Add(User model);
        void Update(User model);
        User Get(int id);
        List<User> GetAll();
        void Delete(int id);
    }
}