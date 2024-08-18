using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WebAPIFornecedor.Business;
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
        public IActionResult Get()
        {
            return Ok(_fornecedorBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Fornecedor fornecedor = _fornecedorBusiness.FindById(id);
            if (fornecedor == null)
                return NotFound();

            return Ok(fornecedor);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            return Ok(_fornecedorBusiness.Create(fornecedor));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return BadRequest();

            return Ok(_fornecedorBusiness.Update(fornecedor));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _fornecedorBusiness.Delete(id);

            return NoContent();
        }
    }
}
