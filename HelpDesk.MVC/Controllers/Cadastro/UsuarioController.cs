
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
        private const int _quantMaxLinhasPorPagina = 5;
        public ActionResult Index()
        {
            var usuarioViewModel = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioRepository.GetAll());
            return View(usuarioViewModel);
        }
        [HttpGet]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            //if (ModelState.IsValid)
            //{
            //    var usuarioDomain = Mapper.Map<UsuarioViewModel, Usuario>(usuario);
            //    _usuarioRepository.Add(usuarioDomain);
            //}
            //return RedirectToAction("index");
            return View();
        }


    }
}