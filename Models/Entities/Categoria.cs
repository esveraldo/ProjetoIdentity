namespace ProjetoIdentity.Models.Entities
{
    public class Categoria
    {
        public Categoria(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;

        }

        public Categoria()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
    }
}