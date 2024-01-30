using ProjetoArquitetura.Models.Models;

namespace ProjetoArquitetura.Negocios.Funcionario
{
    public interface IFuncionario
    {
        List<FuncionarioModel> ObterLista();
        List<FuncionarioModel> ObterListaPorUF(string sigleUF);
        List<FuncionarioModel> ObterListaPorNome(string nome);
        List<FuncionarioModel> ObterListaPorNomeComUF(string nome, string siglaUF);
        List<FuncionarioModel> ObterListaPeloPrimeiroNome(string nome);
        List<FuncionarioModel> ObterListaPeloUltimoNome(string nome);
        FuncionarioModel Obter(string cpf);
        void Alterar(FuncionarioModel funcionario);
        void Inserir(FuncionarioModel funcionario);
        void Excluir(string cpf);
    }
}