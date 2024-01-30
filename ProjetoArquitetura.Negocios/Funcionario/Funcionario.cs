

using ProjetoArquitetura.Infra.Entity;
using ProjetoArquitetura.Models.Models;

namespace ProjetoArquitetura.Negocios.Funcionario
{
    public class Funcionario : IFuncionario
    {
        private readonly Context _context;

        public Funcionario(Context context)
        {
            _context = context;
        }

        public void Alterar(FuncionarioModel funcionario)
        {
            _context.Update(funcionario);
            _context.SaveChangesAsync();
        }
        public void Excluir(string cpf)
        {
            FuncionarioModel funcionario = _context.Funcionarios.Single(x => x.CPF == cpf);
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChangesAsync();
        }
        public void Inserir(FuncionarioModel funcionario)
        {
            _context.Add(funcionario);
            _context.SaveChangesAsync();
        }
        public FuncionarioModel Obter(string cpf) => _context.Funcionarios.Single(x => x.CPF == cpf); 
        public List<FuncionarioModel> ObterLista() => _context.Funcionarios.ToList();
        public List<FuncionarioModel> ObterListaPeloPrimeiroNome(string nome) => _context.Funcionarios.Where(x => x.Nome.StartsWith(nome)).ToList();
        public List<FuncionarioModel> ObterListaPeloUltimoNome(string nome) => _context.Funcionarios.Where(x => x.Nome.EndsWith(nome)).ToList();
        public List<FuncionarioModel> ObterListaPorNome(string nome) => _context.Funcionarios.Where(x => x.Nome.Contains(nome)).ToList();
        public List<FuncionarioModel> ObterListaPorNomeComUF(string nome, string siglaUF) => _context.Funcionarios.Where(x => (x.Nome.Contains(nome) && x.Estado.Equals(siglaUF))).ToList();
        public List<FuncionarioModel> ObterListaPorUF(string sigleUF) => _context.Funcionarios.Where(x => x.Estado.Equals(sigleUF)).ToList();

    }
}
