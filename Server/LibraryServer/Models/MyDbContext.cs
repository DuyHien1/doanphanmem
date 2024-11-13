// Models/MyDbContext.cs
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Reader> Readers { get; set; }
    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Publisher> Publishers { get; set; } = default!;
    public DbSet<ReportCard> ReportCards { get; set; } = default!;
    public DbSet<ReturnCard> ReturnCards { get; set; } = default!;
    public DbSet<BorrowCard> BorrowCards { get; set; } = default!;
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<ReaderCard> ReaderCarts { get; set; } = default!;
    public DbSet<Librarian> Librarians { get; set; } = default!;
    public DbSet<Comment> Comments { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>()
            .HasOne<Publisher>()
            .WithMany()
            .HasForeignKey(b => b.publisherName);

        modelBuilder.Entity<Book>()
            .HasOne<Author>()
            .WithMany()
            .HasForeignKey(b => b.authorName);

        modelBuilder.Entity<ReportCard>()
            .HasOne<Librarian>()
            .WithMany()
            .HasForeignKey(b => b.libId);

        modelBuilder.Entity<BorrowCard>()
            .HasOne<Book>()
            .WithMany()
            .HasForeignKey(b => b.bookId);

        modelBuilder.Entity<Reader>()
            .HasOne(r => r.ReaderCard)
            .WithOne(rc => rc.Reader)
            .HasForeignKey<ReaderCard>(rc => rc.ReaderId);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.BorrowCard)
            .WithOne(br => br.Account)
            .HasForeignKey<BorrowCard>(br => br.userId);

        // Thêm khóa ngoại cho Comment
        modelBuilder.Entity<Comment>()
            .HasOne<Account>()
            .WithMany()
            .HasForeignKey(c => c.UserId);

        modelBuilder.Entity<Comment>()
            .HasOne<Book>()
            .WithMany()
            .HasForeignKey(c => c.BookId);

        // Cấu hình CreatedDate cho Comment
        modelBuilder.Entity<Comment>()
            .Property(c => c.CreatedDate)
            .HasDefaultValueSql("GETUTCDATE()"); // Or equivalent SQL function

    }
}