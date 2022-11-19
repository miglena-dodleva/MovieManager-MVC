using Microsoft.EntityFrameworkCore;
using MovieManager.Entities;

namespace MovieManager.Data
{
    public class MovieManagerDbContext: DbContext
    {
        public MovieManagerDbContext()
        {
            this.Genres = Set<Genre>();
            this.Movies = Set<Movie>();
            this.Users = Set<User>();
            this.UserMovies = Set<UserMovie>();
        }


        public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "Server=.;Database=MovieManager;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Username = "megy",
                Password = "123456789",
                FirstName = "Miglena",
                LastName = "Dodleva"
            });
        }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMovie> UserMovies { get; set; }
    }
}
