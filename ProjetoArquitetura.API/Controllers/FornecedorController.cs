using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoArquitetura.Models.Models;
using ProjetoArquitetura.Negocios.Fornecedor;

namespace ProjetoArquitetura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedor _fornecedor;

        public FornecedorController(IFornecedor fornecedor)
        {
            _fornecedor = fornecedor;
        }

        [HttpGet()]
        public List<FornecedorModel> Get()
        {
            return _fornecedor.ObterLista();
        }
        [HttpGet("ObterListaPorUF")]
        public List<FornecedorModel> GetObterListaPorUF([FromQuery] string sigleUF)
        {
            return _fornecedor.ObterListaPorUF(sigleUF);
        }

        [HttpGet("ObterListaPorNome")]
        public List<FornecedorModel> GetObterListaPorNome([FromQuery] string nome)
        {
            return _fornecedor.ObterListaPorNome(nome);
        }

        [HttpGet("ObterListaPeloPrimeiroNome")]
        public List<FornecedorModel> GetObterListaPeloPrimeiroNome([FromQuery] string nome)
        {
            return _fornecedor.ObterListaPeloPrimeiroNome(nome);
        }

        [HttpGet("ObterListaPeloUltimoNome")]
        public List<FornecedorModel> GetObterListaPeloUltimoNome([FromQuery] string nome)
        {
            return _fornecedor.ObterListaPeloUltimoNome(nome);
        }

        [HttpGet("ObterListaPorNomeComUF")]
        public List<FornecedorModel> GetObterListaPorNomeComUF([FromQuery] string nome, string estado)
        {
            return _fornecedor.ObterListaPorNomeComUF(nome, estado);
        }

        [HttpGet("ObterDadosFornecedor")]
        public FornecedorModel Get([FromQuery] string CNPJ)
        {
            return _fornecedor.Obter(CNPJ);
        }

        [HttpPost()]
        public void Post([FromBody] FornecedorModel fornecedor)
        {
            _fornecedor.Inserir(fornecedor);
        }

        [HttpPut()]
        public void Put([FromBody] FornecedorModel fornecedor)
        {
            _fornecedor.Alterar(fornecedor);
        }

        [HttpDelete()]
        public void Delete([FromQuery] string CNPJ)
        {
            _fornecedor.Excluir(CNPJ);
        }
    }
}
