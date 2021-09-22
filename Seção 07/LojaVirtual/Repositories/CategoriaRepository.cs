using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Repositories {
    public class CategoriaRepository : ICategoriaRepository {

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

        public IEnumerable<Categoria> ObterTodasCategorias() {
            return _banco.Categorias.ToList();
        }
    }
}
