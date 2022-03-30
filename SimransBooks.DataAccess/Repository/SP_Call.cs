using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SimransBooks.DataAccess.Repository.IRepository;
using SimransBookStore.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimransBooks.DataAccess.Repository
{
    public class SP_Call : ISP_Call
    {
        //access the database
        private readonly ApplicationDbContext _db;

        public string ConnectionString { get; }

        private static string ConnectinString = ""; //needed to called the stored procedure

        //constructure to open a sql connection
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }

        // implements the ISP_Call interface
        public void Disopose()
        {
            _db.Dispose();
        }
        public void Execute(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCan = new SqlConnection(ConnectionString))
            {
                sqlCan.Open();
                sqlCan.Execute(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> Lists<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCan = new SqlConnection(ConnectionString))
            {
                sqlCan.Open();
                return sqlCan.Query<T>(procedureName, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var result = SqlMapper.QueryMultiple(sqlCon, procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();
                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                var value = sqlCon.Query<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure), typeof(T));
            }
        }