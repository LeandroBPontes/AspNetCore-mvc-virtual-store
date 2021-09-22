using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private LojaVirtualContext _banco;

        public ColaboradorRepository (LojaVirtualContext banco)
        {
            _banco = banco;

        }
        public void Cadastrar(Colaborador colaborador)
        {
            //adiciona no banco e salva
            _banco.Add(colaborador);
            _banco.SaveChanges();
        }
        public void Atualizar(Colaborador colaborador)
        {
            //atualiza no banco e salva
            _banco.Update(colaborador);
            _banco.SaveChanges();
        }

       

        public void Excluir(int Id)
        {
            //eclui no banco e salva
            Colaborador colaborador = ObterColaborador(Id);
            _banco.Remove(colaborador);
            _banco.SaveChanges();
        }

        public Colaborador Login(string Email, string Senha)
        {
            Colaborador colaborador = _banco.Colaboradores.Where(m => m.Email == Email && m.Senha == Senha).FirstOrDefault();
            return colaborador;
        }

        public Colaborador ObterColaborador(int Id)
        {
            return _banco.Colaboradores.Find(Id);
        }

        public IEnumerable<Colaborador> ObterTodosColaboradores()
        {
            return _banco.Colaboradores.ToList();
        }
    }
}
