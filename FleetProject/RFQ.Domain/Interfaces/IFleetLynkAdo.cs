using Microsoft.Data.SqlClient;
using System.Data;

namespace RFQ.Domain.Interfaces
{
    public interface IFleetLynkAdo
    {
        Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, List<SqlParameter> parameters);
        Task<DataSet> ExecuteStoredProcedureDataSet(string procedureName, List<SqlParameter> parameters);
        Task<DataTable> ExecuteStoredProcedureAsync(List<SqlParameter> parameters);
        Task<DataSet> ExecuteStoredProcedureDataSet(List<SqlParameter> parameters);
        int ExecuteNonQuery(string query, List<SqlParameter> parameters);
        object ExecuteScalar(string query, List<SqlParameter> parameters);
        DataTable ExecuteQuery(string query, List<SqlParameter> parameters);
        Task<DataTable> ExecuteStoredProcedure(string procedureName);
    }
}
