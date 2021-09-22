using LojaVirtual.Libraries.Email;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LojaVirtual.Database;
using LojaVirtual.Repositories;
using LojaVirtual.Repositories.Contracts;
using LojaVirtual.Libraries.Login;
using LojaVirtual.Libraries.Filtro;

namespace LojaVirtual.Controllers
{
    public class HomeController : Controller
    {

        //construtor para fazer injeção de dependencias
        private IClienteRepository _repositoryCliente;
        private INewsLetterRepository _repositoryNewsLetter;
        private LoginCliente _loginCliente;
        public HomeController(IClienteRepository repositoryCliente, INewsLetterRepository repositoryNewsLetter, LoginCliente loginCliente)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryNewsLetter = repositoryNewsLetter;
            _loginCliente = loginCliente;
        }

        //metodo controlador do arquivo Index.cshtml em Views/Home
        [HttpGet]
        public IActionResult Index()
        {   
            return View();
        }

        //vai receber todos os dados enviados que sejam compativeis com NewsLetterEmail
        //formulario de index.cshtml
        //envia para a tabela newsletteremail
        [HttpPost]
        public IActionResult Index([FromForm]NewsLetterEmail newsLetter)
        {
            //verifica as validações em NewsLetterEmail no campo email
             if (ModelState.IsValid)
             {
                
                 //adiciona no banco e salva
                  _repositoryNewsLetter.Cadastrar(newsLetter);
                
                 //quando n é enviado para a view
                 //armazena dados temporariamente
                 TempData["MSG_S"] = "E-mail cadastrado com sucesso! Fique atento às promoções";

                 //redireciona para index
            
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        //metodo controlador do arquivo Contato.cshtml em Views/Home
        public IActionResult Contato()
        {
            return View();
        }

        /// <summary>
        /// Utilizado em conjunto com ContatoEmail para realização de envio de emails
        /// </summary>

        public IActionResult ContatoAcao()
        {

            try
            {
                //em Model/Contato
                Contato contato = new Contato();

                contato.Nome = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                /// <summary>
                /// Validação dos campos
                /// </summary>
                
                var listaMensagens = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);
                bool isValid =  Validator.TryValidateObject(contato, contexto, listaMensagens,true);

                if (isValid)
                {
                    ContatoEmail.EnviarContatoPorEmail(contato);

                    /*
                * Mensagem irá ser apresentada só quando for necessario
                * Através do Razor, utilizado na pagina Contato
                */
                    ViewData["MSG_S"] = "Mensagem de contato enviado com sucesso";
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var texto in listaMensagens)
                    {
                        sb.Append(texto.ErrorMessage + "<br />");
                    }
                    ViewData["MSG_E"] = sb.ToString();
                    ViewData["CONTATO"] = contato;

                }

                /// <summary>
                /// Fim Validação dos campos
                /// </summary>

            }
            catch (Exception e)
            {
                ViewData["MSG_E"] = "Oops! Ocorreu um erro, tente novamente mais tarde!";
                //TODO - Implementar log
            }


            //retornando para a tela de contato
            return View("Contato");



            //return new ContentResult() { Content = string.Format("Dados recebidos com sucesso! <br /> Nome: {0} E-mail: {1} Texto: {2}", contato.Nome, contato.Email, contato.Texto), ContentType = "text/html"};
        }

        //metodo controlador do arquivo Login.cshtml em Views/Home
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm]Cliente cliente)
        {
            Cliente clienteDB = _repositoryCliente.Login(cliente.Email, cliente.Senha);

            if(clienteDB != null)
            {
                _loginCliente.Login(clienteDB);

                return new RedirectResult(Url.Action(nameof(Painel)));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado, verifique o E-mail ou Senha digitados";
                return View();
            }
            
          
        }

        //painel de controle para clientes

        [HttpGet]
        [ClienteAutorizacao]
        //em Filtro -> ClienteAutorizacaoAttribute
        public IActionResult Painel()
        {
            return new ContentResult()
            {
                Content = "Este é o painel"
            };
        }

        //metodo controlador do arquivo CadastroCliente.cshtml em Views/Home
        public IActionResult CadastroCliente()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CadastroCliente([FromForm] Cliente cliente)
        {
            //verifica as validações em NewsLetterEmail no campo email
            if (ModelState.IsValid)
            {

                //adiciona no banco e salva
               _repositoryCliente.Cadastrar(cliente);
               
                //quando n é enviado para a view
                //armazena dados temporariamente
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";

                //redireciona para index
                return RedirectToAction(nameof(CadastroCliente));
            }
            
                return View();
            
        }

        //metodo controlador do arquivo CarrinhoCompras.cshtml em Views/Home
        public IActionResult CarrinhoCompras()
        {
            return View();
        }

    }
}
