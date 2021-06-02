using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories
{
    public class NewsLetterRepository : INewsLetterRepository
    {

        private LojaVirtualContext _banco;

        //recebe do construtor a injeção de dependencias do banco
        //construtor => NewsLetterRepository
        //injeção do banco => LojaVirtualContext
        public NewsLetterRepository(LojaVirtualContext banco)
        {
            _banco = banco;
        }
        public void Cadastrar(NewsLetterEmail newsletter)
        {
            _banco.NewsLetterEmail.Add(newsletter);
            _banco.SaveChanges();
        }

        public IEnumerable<NewsLetterEmail> ObterTodasNewsLetter()
        {
            return _banco.NewsLetterEmail.ToList();
        }
    }
}
