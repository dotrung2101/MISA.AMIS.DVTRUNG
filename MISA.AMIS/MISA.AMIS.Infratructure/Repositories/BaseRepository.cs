using Dapper;
using MISA.AMIS.Core.Interfaces.Repositories;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.AMIS.Infratructure.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity> where MISAEntity : class
    {

        protected IDbConnection _dbConnection;

        protected string _connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port=3306;" +
                "User Id = dev;" +
                "Password =12345678;" +
                "Database = MF824_DVTRUNG_AMIS;" +
                "convert zero datetime=True";

        private string _tableName = typeof(MISAEntity).Name;

        public bool CheckAttributeDuplicate(string attributeName, string value)
        {

            using(_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_CheckPost{attributeName}Exist";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{attributeName}", value);
                var exist = _dbConnection.QueryFirstOrDefault<bool>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                return exist;
            }

        }

        public bool CheckAttributeDuplicate(string attributeName, string value, Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_CheckPut{attributeName}Exist";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{attributeName}", value);
                parameters.Add($"@Id", id);
                var exist = _dbConnection.QueryFirstOrDefault<bool>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                return exist;
            }
        }

        public int Delete(Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_Delete{_tableName}";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_tableName}Id", id);

                var rowAffects = _dbConnection.Execute(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                if (rowAffects > 0)
                {
                    return rowAffects;
                }
                else
                {
                    return 0;
                }
            }
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            using(_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_GetAll{_tableName}s";

                var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure);

                if(entities.Count() > 0)
                {
                    return entities;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public MISAEntity GetById(Guid? id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_Get{_tableName}ById";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{_tableName}Id", id);

                var entity = _dbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters, commandType: CommandType.StoredProcedure);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    return null;
                }
            }
        }

        public int Insert(MISAEntity entity)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_Insert{_tableName}";

                var rowAffects = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);

                if (rowAffects > 0)
                {
                    return rowAffects;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Update(MISAEntity entity, Guid id)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                string sqlCommand = $"Proc_Update{_tableName}";

                var rowAffects = _dbConnection.Execute(sqlCommand, param: entity, commandType: CommandType.StoredProcedure);

                if (rowAffects > 0)
                {
                    return rowAffects;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
