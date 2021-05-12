using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        /// <summary>
        /// Get all records in the table
        /// </summary>
        /// <returns>List of entities</returns>
        IEnumerable<MISAEntity> GetAll();
        /// <summary>
        /// Get record by Id
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns>
        /// enity if record exist
        /// or null
        /// </returns>
        MISAEntity GetById(Guid id);
        /// <summary>
        /// Insert a record to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of records inserted</returns>
        int Insert(MISAEntity entity);
        /// <summary>
        /// Modify a record has id = id in the table
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>number of records modified</returns>
        int Update(MISAEntity entity, Guid id);
        /// <summary>
        /// delete a record has id = id in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>number of records has delete</returns>
        int Delete(Guid id);
    }
}
