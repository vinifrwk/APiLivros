using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLivros.Models
{
    [Table("Livros")]
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tema { get; set; }

        [Required]
        public int Ano { get; set; }

        public int AutorId { get; set; }

        public Autor Autor { get; set; }

    }
}
