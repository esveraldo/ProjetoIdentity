using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoIdentity.Data;
using ProjetoIdentity.Models.Entities;
using ProjetoIdentity.Models.ViewModels;
using System.Linq;

namespace ProjetoIdentity.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProdutosController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(){
            var produtos = _context.Produtos.Include(c => c.Categoria).ToList();
            return View(produtos);
        }

        public IActionResult Details(int? id){
            var produto = _context.Produtos.Include(c => c.Categoria).First(p => p.Id.Equals(id));
            if(produto == null){
                return NotFound();
            }

            return View(produto);
        }

        public IActionResult Create(){
            var categorias = _context.Categorias.ToList();
            var produtoViewModel = new ProdutoFormViewModel { Categorias = categorias };
            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto){

            //VALIDAÇÃO DO LADO DO SERVIDOR, QUANDO JAVASCRIPT ESTIVER DESABILITADO
            if (!ModelState.IsValid)
            {
                var categorias = _context.Categorias.ToList();
                var produtoViewModel = new ProdutoFormViewModel { Categorias = categorias };
                return View(produtoViewModel);
            }

            var p = _context.Add(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id){
            if(id == null){
                NotFound();
            }
            var produto = _context.Produtos.First(p => p.Id.Equals(id));
            var categorias = _context.Categorias.ToList();
            var produtoViewModel = new ProdutoFormViewModel { Produto = produto, Categorias = categorias };
            return View(produtoViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto){
            if(id != produto.Id){
                return NotFound();
            }
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id){
            var produto = _context.Produtos.First(p => p.Id.Equals(id));
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Produto produto){
            var prod = _context.Produtos.First(p => p.Id.Equals(id));
            if(prod.Id != id){
                NotFound();
            }
            _context.Produtos.Remove(prod);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}