using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            ProdutosDAO produtosDAO = new ProdutosDAO();
            IList<Produto> produtos = produtosDAO.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }

        public ActionResult FormCadastraProduto()
        {
            CategoriasDAO categoriasDAO = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = categoriasDAO.Lista();
            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();
            return View();
        }

        /**public ActionResult Adiciona(String nome, float preco, String descricao, int quantidade, int categoriaId)
        {
            Produto produto = new Produto();
            produto.Nome = nome;
            produto.Preco = preco;
            produto.Descricao = descricao;
            produto.Quantidade = quantidade;
            produto.CategoriaId = categoriaId;

            ProdutosDAO produtosDAO = new ProdutosDAO();
            produtosDAO.Adiciona(produto);
            return View();
        }**/

        //Utilização do componente Model Binder e o método somente aceitará requisições via POST devido a anotação
        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idDaInformatica = 1;
            if (produto.CategoriaId.Equals(idDaInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido", "Produto da informática com preço abaixo do permitido.");
            }
            if (ModelState.IsValid)
            {
                ProdutosDAO dao = new ProdutosDAO();
                dao.Adiciona(produto);
                //Redireciona para outra action RedirectToAction("Index", "Controller")
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Produto = produto;
                CategoriasDAO categoriasDAO = new CategoriasDAO();
                ViewBag.Categorias = categoriasDAO.Lista();
                return View("FormCadastraProduto");
            }
        }
    }
}