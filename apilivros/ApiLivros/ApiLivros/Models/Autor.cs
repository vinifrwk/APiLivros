using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiLivros.Models
{
    [Table("Autores")]
    public class Autor
    {
        public Autor()
        {
            Livros = new Collection<Livro>();
        }

        [Key]
        public int AutorId { get; set;}
        
        [Required]
        public string Nome { get; set;}

        public ICollection<Livro> Livros { get; set;}
    
    }
}
