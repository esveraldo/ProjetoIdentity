using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoIdentity.Data;
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
    }
}