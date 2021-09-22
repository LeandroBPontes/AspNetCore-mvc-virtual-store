using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models {
    public class Categoria {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Slug { get; set; }


        /*
         * URL Normal: www.lojavirtual.com.br/categoria/5 (com o id, não fica amigável)
         * Nome: informatica
         *  URL Com Slug: www.lojavirtual.com.br/categoria/informatica
         *  
         *  Nome: Telefone sem fio
         *  Slug: Telefone-sem-fio
         */

        //ponto de interrogação mostra que o int pode ser nulo
        /*
        * auto-relacionamento
        * 1- informatica - Id Null
        * - 2- Mouse: Id 1
        * -- 3 - Mouse Sem fio: Id 2
        * 
        */
        public int? CategoriaPaiId { get; set; }

        /*
         * ORM - EntityFrameworkCore -> autorelacionamento
         */
        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai { get; set; }
       
    }
}
