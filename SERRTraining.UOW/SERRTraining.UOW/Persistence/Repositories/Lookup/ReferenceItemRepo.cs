using Dapper;
using Entities.Lookup;
using SERRTraining.UOW.Core.Repositories.Lookup;
using System.Collections.Generic;
using System.Data;

namespace SERRTraining.UOW.Persistence.Repositories.Lookup
{
    internal class ReferenceItemRepo : Repository<ReferenceItem>, IReferenceItem
    {
        public ReferenceItemRepo(IDbConnection connection) : base(connection) { }

        public List<ReferenceItem> TodoType()
        {
            using (var trans = Connection.BeginTransaction())
            {
                return Connection.Query<ReferenceItem>("US_TodoType", null, trans, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public List<ReferenceItem> Title()
        {
            using (var trans = Connection.BeginTransaction())
            {
                return Connection.Query<ReferenceItem>("US_Title", null, trans, commandType: CommandType.StoredProcedure).AsList();
            }
        }
    }
}