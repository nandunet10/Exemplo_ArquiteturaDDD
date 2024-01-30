using ProjetoArquitetura.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoArquitetura.Negocios.Cliente
{
    public interface ICliente
    {
        List<ClienteModel> ObterLista();
        List<ClienteModel> ObterListaPorUF(string sigleUF);
        List<ClienteModel> ObterListaPorNome(string nome);
        List<ClienteModel> ObterListaPorNomeComUF(string nome, string siglaUF);
        List<ClienteModel> ObterListaPeloPrimeiroNome(string nome);
        List<ClienteModel> ObterListaPeloUltimoNome(string nome);
        ClienteModel Obter(string cpf);
        void Alterar(ClienteModel cliente);
        void Inserir(ClienteModel cliente);
        void Excluir(string cpf);

    }
}
