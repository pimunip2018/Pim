using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.MVC.Controllers
{
    public class ContaController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logoff()
        {
            return View();
        }
        
        [AllowAnonymous]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult EsqueciSenha()
        {
            return View();
        }

        private void EnviarEmailRedefinicaoSenha()
        {
            //var callbackUrl = Url.Action("RedefinirSenha", "Conta", new { id = usuario.Id }, protocol: Request.Url.Scheme);
            var client = new SmtpClient()
            {
                Host = ConfigurationManager.AppSettings["EmailServidor"],
                Port = 25,
                EnableSsl = (ConfigurationManager.AppSettings["EmailSsl"] == "S"),
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["EmailUsuario"],
                    ConfigurationManager.AppSettings["EmailSenha"])
            };

            var mensagem = new MailMessage();
            mensagem.From = new MailAddress(ConfigurationManager.AppSettings["EmailOrigem"], "Controle de Estoque - Como Programar Melhor");
            //mensagem.To.Add(usuario.Email);
            mensagem.Subject = "Redefinição de senha";
            //mensagem.Body = string.Format("Redefina a sua senha <a href='{0}'>aqui</a>", callbackUrl);
            mensagem.IsBodyHtml = true;

            client.Send(mensagem);
        }
    }
}