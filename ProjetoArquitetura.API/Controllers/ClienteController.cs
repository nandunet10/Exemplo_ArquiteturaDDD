using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoArquitetura.Models.Models;
using ProjetoArquitetura.Negocios.Cliente;

namespace ProjetoArquitetura.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;

        public ClienteController(ICliente cliente)
        {
            _cliente = cliente;
        }

        [HttpGet()]
        public List<ClienteModel> Get()
        {
            return _cliente.ObterLista();
        }

        [HttpGet("ObterListaPorUF")]
        public List<ClienteModel> GetObterListaPorUF([FromQuery] string sigleUF)
        {
            return _cliente.ObterListaPorUF(sigleUF);
        }

        [HttpGet("ObterListaPorNome")]
        public List<ClienteModel> GetObterListaPorNome([FromQuery] string nome)
        {
            return _cliente.ObterListaPorNome(nome);
        }

        [HttpGet("ObterListaPeloPrimeiroNome")]
        public List<ClienteModel> GetObterListaPeloPrimeiroNome([FromQuery] string nome)
        {
            return _cliente.ObterListaPeloPrimeiroNome(nome);
        }

        [HttpGet("ObterListaPeloUltimoNome")]
        public List<ClienteModel> GetObterListaPeloUltimoNome([FromQuery] string nome)
        {
            return _cliente.ObterListaPeloUltimoNome(nome);
        }

        [HttpGet("ObterListaPorNomeComUF")]
        public List<ClienteModel> GetObterListaPorNomeComUF([FromQuery] string nome, string estado)
        {
            return _cliente.ObterListaPorNomeComUF(nome, estado);
        }

        [HttpGet("ObterDadosCliente")]
        public ClienteModel Get([FromQuery] string CPF)
        {
            return _cliente.Obter(CPF);
        }

        [HttpPost()]
        public void Post([FromBody] ClienteModel cliente)
        {
            _cliente.Inserir(cliente);
        }

        [HttpPut()]
        public void Put([FromBody] ClienteModel cliente)
        {
            _cliente.Alterar(cliente);
        }

        [HttpDelete()]
        public void Delete([FromQuery] string CPF)
        {
            _cliente.Excluir(CPF);
        }
    }
}
