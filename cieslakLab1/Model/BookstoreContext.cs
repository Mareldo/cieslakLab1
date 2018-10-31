using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cieslakLab1.Model
{
    public class BookstoreContext : DbContext, IUnitOfWork
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genere> Generes { get; set; }
        public DbSet<BookAuthor> BooksAuthors{ get; set; }

        public BookstoreContext(DbContextOptions<BookstoreContext> options) 
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorID, ba.BookID });
            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Author)
                                             .WithMany(a => a.Books)
                                             .HasForeignKey(ba => ba.AuthorID);
            modelBuilder.Entity<BookAuthor>().HasOne(ba => ba.Book)
                                             .WithMany(b => b.Authors)
                                             .HasForeignKey(ba => ba.BookID);
        }
    }
}
