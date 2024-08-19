using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebAPIFornecedor.Business;
using WebAPIFornecedor.Data.VO;
using WebAPIFornecedor.Model;

namespace WebAPIFornecedor.Controllers
{
    [ApiController]
    [Route("api/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly ILogger<FornecedorController> _logger;
        private IFornecedorBusiness _fornecedorBusiness;

        public FornecedorController(ILogger<FornecedorController> logger, IFornecedorBusiness personBusiness)
        {
            _logger = logger;
            _fornecedorBusiness = personBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Fornecedor>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            var fornecedores = _fornecedorBusiness.FindAll();
            if (fornecedores == null || fornecedores.Count == 0)
                return NoContent();

            return Ok(fornecedores);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(200, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Get(long id)
        {
            Fornecedor fornecedor = _fornecedorBusiness.FindById(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] FornecedorVO fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            Fornecedor createdFornecedor = _fornecedorBusiness.Create(fornecedor);
            return CreatedAtAction(nameof(Get), new { id = createdFornecedor.Id }, createdFornecedor);
        }

        [HttpPut("{id:long}")]
        [ProducesResponseType(200, Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public IActionResult Put(long id, [FromBody] FornecedorVO fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            Fornecedor updatedFornecedor = _fornecedorBusiness.Update(id, fornecedor);
            if (updatedFornecedor == null)
                return NotFound();

            return Ok(updatedFornecedor);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            Fornecedor fornecedor = _fornecedorBusiness.FindById(id);
            if (fornecedor == null)
                return NotFound();

            _fornecedorBusiness.Delete(id);
            return NoContent();
        }
    }
}
