using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories {
    public class CategoriaRepository : ICategoriaRepository {

        const int RegistroPorPagina = 10;
        
        LojaVirtualContext _banco;
        public CategoriaRepository(LojaVirtualContext banco) {
            _banco = banco;
        }
        public void Atualizar(Categoria categoria) {
            //atualiza no banco e salva
            _banco.Categorias.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria) {
            //adiciona no banco e salva
            _banco.Categorias.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int Id) {
            //exclui no banco e salva
            Categoria categoria = ObterCategoria(Id);
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }
       
        public Categoria ObterCategoria(int Id) {
           return _banco.Categorias.Find(Id);
            
        }

       
        public IPagedList<Categoria> ObterTodasCategorias(int? pagina) {
            //caso pagina seja nulo, recebe 1
            int NumeroPagina = pagina ?? 1;
            // return _banco.Categorias.ToPagedList<Categoria>(NumeroPagina, RegistroPorPagina);
            //incluindo a categoriaPai para utilização no razor
            return _banco.Categorias.Include(a=>a.CategoriaPai).ToPagedList<Categoria>(NumeroPagina, RegistroPorPagina);
        }
    }
}
