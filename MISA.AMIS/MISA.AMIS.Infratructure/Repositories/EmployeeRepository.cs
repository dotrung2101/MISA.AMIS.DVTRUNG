using Dapper;
using MISA.AMIS.Core.Entities;
using MISA.AMIS.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.AMIS.Infratructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> FilterAndGetInRange(int fromIndex, int numberOfRecords, string fullName, Guid? departmentId)
        {

            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_FilterAndGetEmployeesInRange";

                DynamicParameters parameters = new DynamicParameters();

                parameters.Add($"@fullName", fullName);
                parameters.Add($"@departmentId", departmentId);
                parameters.Add($"@fromIndex", fromIndex);
                parameters.Add($"@numberOfRecords", numberOfRecords);

                var customers = _dbConnection.Query<Employee>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                return customers;
            }
        }
    }
}
