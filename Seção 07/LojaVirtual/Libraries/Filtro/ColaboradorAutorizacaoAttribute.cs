using LojaVirtual.Libraries.Login;
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro {
    /*
    Tipos de Filtros:
   - Autorização - IAuthorizationFilter // usuario nao consegue seguir
   - Recurso -  IResourceFilter
   - Ação - IActionFilter
   - Exceção - IExceptionFilter
   - Resultado - IResultFilter
   */
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter {
        LoginColaborador _loginColaborador;
        public void OnAuthorization(AuthorizationFilterContext context) {

            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
           Colaborador colaborador = _loginColaborador.GetColaborador();
            if (colaborador == null) {
                context.Result = new ContentResult() { Content = "Acesso Negado." };

            }
        }
    }
}
