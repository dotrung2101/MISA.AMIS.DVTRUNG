using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity> where MISAEntity : class
    {
        IEnumerable<MISAEntity> GetAll();
        MISAEntity GetById(Guid id);
        int Insert(MISAEntity entity);
        int Update(MISAEntity entity, Guid id);
        int Delete(Guid id);
    }
}
