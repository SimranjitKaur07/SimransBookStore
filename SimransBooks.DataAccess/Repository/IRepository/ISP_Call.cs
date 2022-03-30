using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimransBooks.DataAccess.Repository.IRepository
{
   public interface ISP_Call
    {
        // first coloumn of frist row the result set
        T Single<T>(string procedurename, DynamicParameters param = null);
        // execute something to database but not reterieve
       void Execute(string procedurename, DynamicParameters param = null);
        // reterive the complete row
       T OneRecords<T>(string procedurename, DynamicParameters param = null);
        // get all rows
       IEnumerable<T> Lists<T>(string procedurename, DynamicParameters param = null);
        //stored procedure that return two tables
        Tuple<IEnumerable<T>,IEnumerable<T2>> Lists<T1, T2>(string procedurename, DynamicParameters param = null);
    }
}
