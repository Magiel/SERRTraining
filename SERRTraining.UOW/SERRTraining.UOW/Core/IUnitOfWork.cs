using SERRTraining.UOW.Core.Repositories.Core;
using SERRTraining.UOW.Core.Repositories.Lookup;
using System;

namespace SERRTraining.UOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITodo TodoRepository { get; }
        IUser UserRepository { get; }
        IReferenceItem ReferenceItemRepository { get; }
    }
}