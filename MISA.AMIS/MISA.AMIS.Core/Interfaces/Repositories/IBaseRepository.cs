using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Repositories
{
    public interface IBaseRepository<MISAEntity> where MISAEntity : class
    {
        IEnumerable<MISAEntity> GetAll();
        MISAEntity GetById(Guid? id);
        int Insert(MISAEntity entity);
        int Update(MISAEntity entity, Guid id);
        int Delete(Guid id);

        bool CheckAttributeDuplicate(string attributeName, string value);
        bool CheckAttributeDuplicate(string attributeName, string value, Guid id);
    }
}
