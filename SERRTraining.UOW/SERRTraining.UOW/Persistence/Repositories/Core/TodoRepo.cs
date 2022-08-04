using Dapper;
using Entities.Core;
using SERRTraining.UOW.Core.Repositories.Core;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@TodoID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: id);

            using (var trans = Connection.BeginTransaction())
            {
                Connection.Execute("UD_Todo", parms, commandType: CommandType.StoredProcedure, transaction: trans);
                trans.Commit();
            }
        }

        public Todo Get(int id)
        {
            DynamicParameters parms = new DynamicParameters();
            parms.Add("@TodoID", dbType: DbType.Int32, direction: ParameterDirection.Input, value: id);

            using (var trans = Connection.BeginTransaction())
            {
                return Connection.Query<Todo>("US_TodoByID", parms, trans, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<Todo> GetAll()
        {
            using (var trans = Connection.BeginTransaction())
            {
                return Connection.Query<Todo>("US_TodoAll", null, trans, commandType: CommandType.StoredProcedure).AsList();
            }
        }

        public void Update(Todo model)
        {
            var parameters = (object)MappingUpdate(model);

            DynamicParameters parms = new DynamicParameters();
            parms.AddDynamicParams(parameters);

            using (var trans = Connection.BeginTransaction())
            {
                Connection.Execute("UU_Todo", parms, commandType: CommandType.StoredProcedure, transaction: trans);
                trans.Commit();
            }
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

        internal dynamic MappingUpdate(Todo t)
        {
            return new
            {
                t.TodoID,
                t.UserID,
                t.TodoTypeID,
                t.DueDate,
                t.Comment
            };
        }
    }
}