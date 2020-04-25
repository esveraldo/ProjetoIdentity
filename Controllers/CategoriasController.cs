using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoIdentity.Data;
using ProjetoIdentity.Models;
using ProjetoIdentity.Models.Entities;
using System.Linq;

namespace ProjetoIdentity.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoriasController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(){
            var categorias = _context.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria){
            if(ModelState.IsValid){
                _context.Categorias.Add(categoria);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id){

            if(id == null){
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado." });
            };

            var categoria = _context.Categorias.First(c => c.Id.Equals(id));

            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Categoria categoria){

            if(categoria.Id != id){
                return RedirectToAction(nameof(Error), new {message = "O id fornecido não corresponde"});
            }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Error(string message){

            var viewModel = new ErrorViewModel {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View();
        }
    }
}