using MISA.AMIS.Core.CustomAttributes;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces.Repositories;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity : class
    {
        
        IBaseRepository<MISAEntity> _baseRepository;

        protected List<Object> _listValidate;

        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public int Delete(Guid id)
        {
            return _baseRepository.Delete(id);
        }

        public IEnumerable<MISAEntity> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public MISAEntity GetById(Guid id)
        {
            return _baseRepository.GetById(id);
        }

        public int Insert(MISAEntity entity)
        {
            //Validate post data
            ValidateData(entity);

            return _baseRepository.Insert(entity);
        }

        /// <summary>
        /// Validate post data and add to _listValidate
        /// Throw EmployeeException if number of validate > 0 
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: dvtrung
        private void ValidateData(MISAEntity entity)
        {
            _listValidate = new List<Object>();
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotNull), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotNull).Msg });
                    }
                }

                requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotDuplicate), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (_baseRepository.CheckAttributeDuplicate(property.Name, propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotDuplicate).Msg });
                    }
                }


            }

            //call to child class
            CustomValidate(entity);

            if (_listValidate.Count > 0)
            {
                throw new EmployeeException(_listValidate.ToArray());
            }
        }
        /// <summary>
        /// Child class's validate post data
        /// </summary>
        /// <param name="entity"></param>
        /// CreatedBy: dvtrung
        protected virtual void CustomValidate(MISAEntity entity)
        {

        }
        /// <summary>
        /// Validate put data and add to listValidate
        /// throw EmployeeException if number of validate > 0
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// CreatedBy: dvtrung
        private void ValidateData(MISAEntity entity, Guid id)
        {
            _listValidate = new List<Object>();
            var properties = typeof(MISAEntity).GetProperties();

            foreach (var property in properties)
            {
                var requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotNull), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);
                    if(propertyValue == null)
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotNull).Msg });
                    }
                    else if (string.IsNullOrEmpty(propertyValue.ToString()))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotNull).Msg });
                    }
                }

                requiredProperties = property.GetCustomAttributes(typeof(MISARequiredNotDuplicate), true);

                if (requiredProperties.Length > 0)
                {
                    var propertyValue = property.GetValue(entity);

                    if (_baseRepository.CheckAttributeDuplicate(property.Name, propertyValue.ToString(), id))
                    {
                        _listValidate.Add(new { devMsg = (requiredProperties[0] as MISARequiredNotDuplicate).Msg });
                    }
                }


            }
            //call to child class's validate
            CustomValidate(entity, id);

            if (_listValidate.Count > 0)
            {
                throw new EmployeeException(_listValidate.ToArray());
            }
        }

        /// <summary>
        /// Child class's custom validate
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        protected virtual void CustomValidate(MISAEntity entity, Guid id)
        {

        }

        public int Update(MISAEntity entity, Guid id)
        {
            //Validate put data
            ValidateData(entity, id);

            return _baseRepository.Update(entity, id);
        }
    }
}
