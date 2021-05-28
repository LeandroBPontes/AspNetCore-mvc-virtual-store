using LojaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //algoritmo para envio de emails

            /*
             SMTP -> Servidor que vai enviar a mensagem
             */

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            //smtp.Credentials = new NetworkCredential("leandrobpontes1996@gmail.com","1718863G$");
            smtp.EnableSsl = true;

            /*
             * Mensagem construida
             */

            string corpoMsg = string.Format("<h2> Contato - Loja Virtual </h2>" +
                "<br /><b>Nome: </b> {0} <br />" +
                "<b>E-mail: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente do site Loja Virtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            /*
             * MailMessage -> construir a menssagem
             */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress("leandrobpontes1996@gmail.com");
           
            mensagem.To.Add("leandropontes123@hotmail.com");
           
            mensagem.Subject = "Contato Loja Virtual - E-mail" + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            //envio
            smtp.Send(mensagem);
        }
    }
}
