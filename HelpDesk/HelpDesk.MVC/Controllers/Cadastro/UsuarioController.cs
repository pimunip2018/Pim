
using AutoMapper;
using HelpDesk.Domain.Entities;
using HelpDesk.Infra.Data.Repositories;
using HelpDesk.MVC.Models.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelpDesk.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());
            return View(usuarioViewModel);
        }
    }
}