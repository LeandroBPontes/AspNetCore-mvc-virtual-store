using LojaVirtual.Database;
using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        //construtor para o banco
        private LojaVirtualContext _banco;
        public ClienteRepository(LojaVirtualContext banco)
        {
            _banco = banco;

        }
        public void Atualizar(Cliente cliente)
        {
            //atualiza no banco e salva
            _banco.Clientes.Update(cliente);
            _banco.SaveChanges();
        }

        public void Cadastrar(Cliente cliente)
        {
            //adiciona no banco e salva
            _banco.Clientes.Add(cliente);
            _banco.SaveChanges();
        }

        public void Excluir(int Id)
        {
            //eclui no banco e salva
            Cliente cliente = ObterCliente(Id);
            _banco.Remove(cliente);
            _banco.SaveChanges();
        }

        public Cliente Login(string Email, string Senha)
        {
            Cliente cliente = _banco.Clientes.Where(m=> m.Email == Email && m.Senha == Senha).First();
            return cliente;
        }

        public Cliente ObterCliente(int Id)
        {
            return _banco.Clientes.Find(Id);
        }

        public List<Cliente> ObterTodosClientes()
        {
            return _banco.Clientes.ToList();
        }
    }
}
