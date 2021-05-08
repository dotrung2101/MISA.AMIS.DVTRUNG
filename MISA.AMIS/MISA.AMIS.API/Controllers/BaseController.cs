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
