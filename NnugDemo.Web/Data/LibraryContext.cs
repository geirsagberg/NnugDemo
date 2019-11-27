using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NnugDemo.Web.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NnugDemo;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author {
                    Id = 1,
                    FirstName = "James",
                    LastName = "S. A. Corey"
                },
                new Author {
                    Id = 2,
                    FirstName = "Will",
                    LastName = "Wight"
                },
                new Author {
                    Id = 3,
                    FirstName = "Isaac",
                    LastName = "Asimov"
                }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book {
                    Id = 1,
                    AuthorId = 1,
                    Title = "Leviathan Wakes"
                },
                new Book {
                    Id = 2,
                    AuthorId = 1,
                    Title = "Caliban's War"
                },
                new Book {
                    Id = 3,
                    AuthorId = 1,
                    Title = "Abaddon's Gate"
                },
                new Book {
                    Id = 4,
                    AuthorId = 2,
                    Title = "House of Blades"
                },
                new Book {
                    Id = 5,
                    AuthorId = 2,
                    Title = "Unsouled"
                },
                new Book {
                    Id = 6,
                    AuthorId = 3,
                    Title = "I, Robot"
                },
                new Book {
                    Id = 7,
                    AuthorId = 3,
                    Title = "Foundation"
                }
            );

        }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string FullName => $"{FirstName} {LastName}";

        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
