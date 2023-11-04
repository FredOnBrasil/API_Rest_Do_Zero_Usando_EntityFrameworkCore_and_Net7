using DevEventAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevEventAPI.Persistence
{
    public class EventosDbContext: DbContext
    {
        /// <summary>
        /// Usando Entity Framework Core colocada herança ': DbContext' acima, e o código abaixo muda
        /// </summary>
        /// <param name="options"></param>
        public EventosDbContext(DbContextOptions<EventosDbContext> options) : base(options)
        {
        }
        
        public DbSet<Evento> Eventos { get; set; }

        /// <summary>
        /// Aqui definimos o nosso identificador unico como o Id
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>()
                .HasKey(e => e.Id);
        }

        // ReSharper disable once InvalidXmlDocComment
        /// <summary>
        /// Sem o uso do Entity Framework Core
        /// </summary>
        //public EventosDbContext()
        //{
        //    Eventos = new List<Evento>();
        //}
        //public List<Evento> Eventos { get; set; }
    }
}
