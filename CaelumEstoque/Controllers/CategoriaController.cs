using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO categoriaDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriaDAO.Lista();
            ViewBag.Categorias = categorias;
            
            return View();
        }

        public ActionResult FormCadastraCategoria()
        {
            ViewBag.Categoria = new CategoriaDoProduto();
            return View();
        }

        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            if (ModelState.IsValid)
            {
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                categoriasDAO.Adiciona(categoria);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categoria = categoria;
                return View("FormCadastraCategoria");
            }
            
        }
    }
}