using Entities.Lookup;
using System.Collections.Generic;

namespace SERRTraining.UOW.Core.Repositories.Lookup
{
    public interface IReferenceItem : IRepository<ReferenceItem>
    {
        List<ReferenceItem> TodoType();
        List<ReferenceItem> Title();
    }
}