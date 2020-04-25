using System.ComponentModel.DataAnnotations;

namespace ProjetoIdentity.Models.Entities
{
    public class Produto
    {
        public Produto(int id, string nome, string descricao, int categoriaId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.CategoriaId = categoriaId;

        }

        public Produto()
        {

        }
        
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

    }
}