using Microsoft.EntityFrameworkCore;

namespace BussinessObject.Models;

public partial class ProjectPrn211Context : DbContext
{
    public ProjectPrn211Context()
    {
    }

    public ProjectPrn211Context(DbContextOptions<ProjectPrn211Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookBorrowingRegistrationForm> BookBorrowingRegistrationForms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HIEU;Initial Catalog=ProjectPrn211;Persist Security Info=True;User ID=sa;Password=123;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(50)
                .HasColumnName("author_name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookDescription)
                .HasMaxLength(500)
                .HasColumnName("book_description");
            entity.Property(e => e.BookImg).HasColumnName("book_img");
            entity.Property(e => e.BookName)
                .HasMaxLength(50)
                .HasColumnName("book_name");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Book_Author");
        });

        modelBuilder.Entity<BookBorrowingRegistrationForm>(entity =>
        {
            entity.HasKey(e => e.BookRegistrationForm);

            entity.ToTable("BookBorrowingRegistrationForm");

            entity.Property(e => e.BookRegistrationForm).HasColumnName("book_registration_form");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LoanBorowing).HasColumnName("loan_borowing");

            entity.HasOne(d => d.Book).WithMany(p => p.BookBorrowingRegistrationForms)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_BookBorrowingRegistrationForm_Book");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.BookBorrowingRegistrationForms)
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_BookBorrowingRegistrationForm_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.PassWord).HasColumnName("pass_word");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
