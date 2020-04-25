using System.Collections.Generic;
using ProjetoIdentity.Models.Entities;

namespace ProjetoIdentity.Models.ViewModels
{
    public class ProdutoFormViewModel
    {
        public Produto Produto { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
    }
}