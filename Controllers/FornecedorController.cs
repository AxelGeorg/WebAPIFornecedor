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
    [Route("api/[controller]/v1")]
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
        [ProducesResponseType((200), Type = typeof(List<Fornecedor>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_fornecedorBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(Fornecedor))]
        [ProducesResponseType(204)]
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
        [ProducesResponseType((200), Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] FornecedorVO fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            return Ok(_fornecedorBusiness.Create(fornecedor));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(Fornecedor))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            return Ok(_fornecedorBusiness.Update(fornecedor));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _fornecedorBusiness.Delete(id);

            return NoContent();
        }
    }
}
