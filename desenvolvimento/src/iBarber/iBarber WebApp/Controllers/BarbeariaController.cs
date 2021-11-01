using iBarber_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iBarber_WebApp.Controllers
{
    public class BarbeariaController : Controller
    {
        private static List<Barbearia> listaDeBarbearia = new List<Barbearia>
        {
            new Barbearia { CNPJ = "12345678910123", Nome = "Gustavo", Local = "Av, 1"},
            new Barbearia { CNPJ = "12345678910124", Nome = "Agnaldo", Local = "Av, 2"},
            new Barbearia { CNPJ = "12345678910125", Nome = "Bigodon", Local = "Av, 3"}


        };

        public IActionResult Index(string cnpj, string barbearia, string local)
        {
            var objeto = new Barbearia();
            objeto.CNPJ = cnpj;
            objeto.Nome = barbearia;
            objeto.Local = local;

            return View(objeto);
        }

        [HttpGet]

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult AdicionarConfirmacao(Barbearia barbearia)
        {
            var obj = listaDeBarbearia.FirstOrDefault(item => item.CNPJ == barbearia.CNPJ);

            if (obj != null)
                obj.Nome = barbearia.Nome;
                //listaDeBarbearia.Update(barbearia);
            else
                listaDeBarbearia.Add(barbearia);

            return RedirectToAction("Listar");
        }

        [HttpGet]

        public IActionResult Editar(string cnpj)
        {
            var barbearia = listaDeBarbearia.First(item => item.CNPJ == cnpj);
            return View("Adicionar", barbearia);
        }

        public IActionResult Listar()
        {
            return View(listaDeBarbearia);
        }

        public IActionResult Excluir(string cnpj)
        {
            var barbearia = listaDeBarbearia.First(f => f.CNPJ == cnpj);
            listaDeBarbearia.Remove(barbearia);

            return RedirectToAction("Listar");
        }

    }
}
