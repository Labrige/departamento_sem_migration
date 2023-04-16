using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CRUD_departamento_sem_migration.Controllers
{
    public class InstituicaoController : Controller
    {
        private static IList<Instituicao> instituicoes = new List<Instituicao>()
        {
            new Instituicao
            {
                Id=1,
                Nome = "Hogwarts",
                Endereco = "Escócia"
            },
            new Instituicao
            {
                Id=2,
                Nome = "Mansão Maromba",
                Endereco = "Brasil"
            }
        };
        public IActionResult Index()
        {
            return View(instituicoes);
        }
        public IActionResult Create()
        { return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instituicao instituicao)
        {
            instituicao.Id = instituicoes.Select(i => i.Id).Max() + 1;
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(long id)
        {
            return View(instituicoes.Where(i =>  i.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.Id == instituicao.Id).First());
            instituicoes.Add(instituicao);
            return RedirectToAction("Index");
        }

        public IActionResult Details(long id)
        {
            return View(instituicoes.Where(i => i.Id == id).First());
        }

        public IActionResult Delete(long id)
        {
            return View(instituicoes.Where(i => i.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Instituicao instituicao)
        {
            instituicoes.Remove(instituicoes.Where(i => i.Id == instituicao.Id).First());
            return RedirectToAction("Index");
        }
    }
}