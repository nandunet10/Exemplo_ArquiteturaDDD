using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoArquitetura.Models.Models;
using ProjetoArquitetura.Negocios.Funcionario;

namespace ProjetoArquitetura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _funcionario;

        public FuncionarioController(IFuncionario funcionario)
        {
            _funcionario = funcionario;
        }

        [HttpGet()]
        public List<FuncionarioModel> Get()
        {
            return _funcionario.ObterLista();
        }

        [HttpGet("ObterListaPorUF")]
        public List<FuncionarioModel> GetObterListaPorUF([FromQuery] string sigleUF)
        {
            return _funcionario.ObterListaPorUF(sigleUF);
        }

        [HttpGet("ObterListaPorNome")]
        public List<FuncionarioModel> GetObterListaPorNome([FromQuery] string nome)
        {
            return _funcionario.ObterListaPorNome(nome);
        }

        [HttpGet("ObterListaPeloPrimeiroNome")]
        public List<FuncionarioModel> GetObterListaPeloPrimeiroNome([FromQuery] string nome)
        {
            return _funcionario.ObterListaPeloPrimeiroNome(nome);
        }

        [HttpGet("ObterListaPeloUltimoNome")]
        public List<FuncionarioModel> GetObterListaPeloUltimoNome([FromQuery] string nome)
        {
            return _funcionario.ObterListaPeloUltimoNome(nome);
        }

        [HttpGet("ObterListaPorNomeComUF")]
        public List<FuncionarioModel> GetObterListaPorNomeComUF([FromQuery] string nome, string estado)
        {
            return _funcionario.ObterListaPorNomeComUF(nome, estado);
        }

        [HttpGet("ObterDadosFuncionarios")]
        public FuncionarioModel Get([FromQuery] string CPF)
        {
            return _funcionario.Obter(CPF);
        }

        [HttpPost()]
        public void Post([FromBody] FuncionarioModel funcionario)
        {
            _funcionario.Inserir(funcionario);
        }

        [HttpPut()]
        public void Put([FromBody] FuncionarioModel funcionario)
        {
            _funcionario.Alterar(funcionario);
        }

        [HttpDelete()]
        public void Delete([FromQuery] string CPF)
        {
            _funcionario.Excluir(CPF);
        }
    }
}
