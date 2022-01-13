using ApiLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLivros.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
       
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {

            model.Entity<Livro>()
                .HasData(
                    new Livro { LivroId = 1, Nome = "Livro 1 lero lero", Tema = "Comedia", Ano = 2020, AutorId = 1, },
                    new Livro { LivroId = 2, Nome = "Roubaram meu celular", Tema = "Drama", Ano = 2021, AutorId = 2 }
                );

        }

    }
}
