using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    /// <summary>
    /// interface base repository
    /// </summary>
    /// <typeparam name="MISAEntity"></typeparam>
    /// CreatedBy: dvtrung
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
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
        /// CreatedBy: dvtrung
        MISAEntity GetById(Guid? id);
        /// <summary>
        /// Insert a record to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of records inserted</returns>
        /// CreatedBy: dvtrung
        int Insert(MISAEntity entity);
        /// <summary>
        /// Modify a record has id = id in the table
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns>number of records modified</returns>
        /// CreatedBy: dvtrung
        int Update(MISAEntity entity, Guid id);
        /// <summary>
        /// delete a record has id = id in the table
        /// </summary>
        /// <param name="id"></param>
        /// <returns>number of records has delete</returns>
        /// CreatedBy: dvtrung
        int Delete(Guid id);
        /// <summary>
        /// Check value of attribute is exist in table
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <returns>
        ///true if value exist or false
        /// </returns>
        /// CreatedBy: dvtrung
        bool CheckAttributeDuplicate(string attributeName, string value);
        /// <summary>
        /// Check value of attribute is exist in table
        /// </summary>
        /// <param name="attributeName"></param>
        /// <param name="value"></param>
        /// <param name="id"></param>
        /// <returns>
        ///true if value exist or false
        /// </returns>
        /// CreatedBy: dvtrung
        bool CheckAttributeDuplicate(string attributeName, string value, Guid id);
    }
}
