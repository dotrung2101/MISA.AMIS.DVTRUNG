using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.AMIS.API.Controllers
{
    public class BaseController<MISAEntity> : ControllerBase where MISAEntity : class
    {
        IBaseService<MISAEntity> _baseService;

        public BaseController(IBaseService<MISAEntity> baseService) : base()
        {
            _baseService = baseService;
        }

        /// <summary>
        /// Get all records from table
        /// </summary>
        /// <returns>
        ///200: if has more than one record
        ///204: if has no record
        /// </returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetAll();

            if(entities == null)
            {
                return NoContent();
            }

            if(entities.Count() > 0)
            {
                return Ok(entities);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///200: if has a record match id
        ///204: if not
        /// </returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _baseService.GetById(id);

            if(entity == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(entity);
            }
        }
        /// <summary>
        /// Insert a record to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>
        ///201: if insert succeed
        ///400: if data is not validate
        /// </returns>
        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var rowAffects = _baseService.Insert(entity);

            if(rowAffects > 0)
            {
                return StatusCode(201, rowAffects);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Modify the record has id match id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>
        ///200: if modify succeed
        ///400: if data not validate
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, MISAEntity entity)
        {
            var rowAffects = _baseService.Update(entity, id);

            if (rowAffects > 0)
            {
                return StatusCode(200, rowAffects);
            }
            else
            {
                return NoContent();
            }
        }
        /// <summary>
        /// Delete the record has id match id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        ///200: if delete succeed
        /// </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var rowAffects = _baseService.Delete(id);

            if (rowAffects > 0)
            {
                return StatusCode(200, rowAffects);
            }
            else
            {
                return NoContent();
            }
        }

    }
}
