using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        /*
         * precisa retornar ActionResult ou IActionResult 
         * 
         * 
         */
        public ActionResult Visualizar()
        {
            // é possivel retornar qualquer classe com final Result
            //neste caso ContentResult()
            //return new ContentResult() { Content = "<h3> Produto -> Visualizar </h3>", ContentType = "text/html" };
            //automaticamente busca na pasta Views a pasta produto com o arquivo Visualizar

            //chama o metodo criado da view model
            Produto produto = GetProduto();
            return View(produto);
        }
        
        //cria metodo para obter produto do model
        private Produto GetProduto()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Xbox One X",
                Descricao = "Jogue em 4k",
                Valor = 2000.00M
            };
        }

    }
}
