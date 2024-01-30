

using ProjetoArquitetura.Infra.Entity;
using ProjetoArquitetura.Models.Models;

namespace ProjetoArquitetura.Negocios.Fornecedor
{
    public class Fornecedor : IFornecedor
    {
        private readonly Context _context;

        public Fornecedor(Context context)
        {
            _context = context;
        }

        public void Alterar(FornecedorModel fornecedor)
        {
            _context.Update(fornecedor);
            _context.SaveChangesAsync();
        }
        public void Excluir(string cnpj)
        {
            FornecedorModel fornecedor = _context.Fornecedores.Single(x => x.CNPJ == cnpj);
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();
        }
        public void Inserir(FornecedorModel fornecedor)
        {
            _context.Add(fornecedor);
            _context.SaveChangesAsync();
        }
        public FornecedorModel Obter(string cnpj) => _context.Fornecedores.Single(x => x.CNPJ == cnpj);
        public List<FornecedorModel> ObterLista() => _context.Fornecedores.ToList(); 
        public List<FornecedorModel> ObterListaPeloPrimeiroNome(string nome) => _context.Fornecedores.Where(x => x.Nome.StartsWith(nome)).ToList();
        public List<FornecedorModel> ObterListaPeloUltimoNome(string nome) => _context.Fornecedores.Where(x => x.Nome.EndsWith(nome)).ToList();
        public List<FornecedorModel> ObterListaPorNome(string nome) => _context.Fornecedores.Where(x => x.Nome.Contains(nome)).ToList();
        public List<FornecedorModel> ObterListaPorNomeComUF(string nome, string siglaUF) => _context.Fornecedores.Where(x => (x.Nome.Contains(nome) && x.Estado.Equals(siglaUF))).ToList();
        public List<FornecedorModel> ObterListaPorUF(string sigleUF) => _context.Fornecedores.Where(x => x.Estado.Equals(sigleUF)).ToList();

    }
}
