

using ProjetoArquitetura.Models.Models;

namespace ProjetoArquitetura.Negocios.Fornecedor
{
    public interface IFornecedor
    {
        List<FornecedorModel> ObterLista();
        List<FornecedorModel> ObterListaPorUF(string sigleUF);
        List<FornecedorModel> ObterListaPorNome(string nome);
        List<FornecedorModel> ObterListaPorNomeComUF(string nome, string siglaUF);
        List<FornecedorModel> ObterListaPeloPrimeiroNome(string nome);
        List<FornecedorModel> ObterListaPeloUltimoNome(string nome);
        FornecedorModel Obter(string cnpj);
        void Alterar(FornecedorModel fornecedor);
        void Inserir(FornecedorModel fornecedor);
        void Excluir(string cnpj);
    }
}
