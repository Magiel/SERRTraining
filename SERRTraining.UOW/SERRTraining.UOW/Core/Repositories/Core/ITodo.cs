using Entities.Core;
using System.Collections.Generic;

namespace SERRTraining.UOW.Core.Repositories.Core
{
    public interface ITodo : IRepository<Todo>
    {
        int Add(Todo model);
        void Update(Todo model);
        Todo Get(int id);
        List<Todo> GetAll();
        void Delete(int id);
    }
}