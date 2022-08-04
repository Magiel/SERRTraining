using Dapper;
using Entities.Core;
using SERRTraining.UOW.Core.Repositories.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERRTraining.UOW.Persistence.Repositories.Core
{
    internal class TodoRepo : Repository<Todo>, ITodo
    {
        public TodoRepo(IDbConnection connection) : base(connection) { }

        public int Add(Todo model)
        {
            int retId;
            var parameters = (object)MappingInsert(model);

            DynamicParameters parms = new DynamicParameters();
            parms.AddDynamicParams(parameters);

            parms.Add("@RowID", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            using (var trans = Connection.BeginTransaction())
            {
                Connection.Execute("UI_Todo", parms, commandType: CommandType.StoredProcedure, transaction: trans);
                trans.Commit();
                retId = parms.Get<int>("@RowID");
            }

            return retId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Todo Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Todo> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Todo model)
        {
            throw new NotImplementedException();
        }

        internal dynamic MappingInsert(Todo t)
        {
            return new
            {
                t.UserID,
                t.TodoTypeID,
                t.DueDate,
                t.Comment
            };
        }
    }
}