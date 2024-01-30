using ProjetoArquitetura.Infra.Entity;
using ProjetoArquitetura.Models.Models;

namespace ProjetoArquitetura.Negocios.Cliente
{
    public class Cliente : ICliente
    {
        private readonly Context _context;

        public Cliente(Context context)
        {
            _context = context;
        }

        public void Alterar(ClienteModel cliente)
        {
            _context.Update(cliente);
            _context.SaveChangesAsync();
        }

        public void Excluir(string cpf)
        {
            ClienteModel cliente = _context.Clientes.Single(x => x.CPF == cpf);
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void Inserir(ClienteModel cliente)
        {
            _context.Add(cliente);
            _context.SaveChangesAsync();
        }

        public ClienteModel Obter(string cpf) => _context.Clientes.SingleOrDefault(x => x.CPF.Equals(cpf)); 
        public List<ClienteModel> ObterLista() => _context.Clientes.ToList(); 
        public List<ClienteModel> ObterListaPeloPrimeiroNome(string nome) => _context.Clientes.Where(x => x.Nome.StartsWith(nome)).ToList();   
        public List<ClienteModel> ObterListaPeloUltimoNome(string nome) => _context.Clientes.Where(x => x.Nome.EndsWith(nome)).ToList(); 
        public List<ClienteModel> ObterListaPorNome(string nome) => _context.Clientes.Where(x => x.Nome.Contains(nome)).ToList();
        public List<ClienteModel> ObterListaPorNomeComUF(string nome, string siglaUF) => _context.Clientes.Where(x => (x.Nome.Contains(nome) && x.Estado.Equals(siglaUF))).ToList();
        public List<ClienteModel> ObterListaPorUF(string sigleUF) => _context.Clientes.Where(x => x.Estado.Equals(sigleUF)).ToList(); 

    }
}
