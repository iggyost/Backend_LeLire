using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend_LeLire.ApplicationData;

public partial class LeLireLightDbContext : DbContext
{
    public LeLireLightDbContext()
    {
    }

    public LeLireLightDbContext(DbContextOptions<LeLireLightDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BooksSource> BooksSources { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    public virtual DbSet<LibraryBook> LibraryBooks { get; set; }

    public virtual DbSet<LibraryView> LibraryViews { get; set; }

    public virtual DbSet<ReaderDatum> ReaderData { get; set; }

    public virtual DbSet<ShowcaseView> ShowcaseViews { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=IgorPc\\SQLEXPRESS; Database=LeLireLightDb; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Author)
                .HasMaxLength(150)
                .HasColumnName("author");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("cost");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.PageCount).HasColumnName("page_count");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_Genres");
        });

        modelBuilder.Entity<BooksSource>(entity =>
        {
            entity.HasKey(e => e.BookSourceId);

            entity.Property(e => e.BookSourceId).HasColumnName("book_source_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.PageNum).HasColumnName("page_num");
            entity.Property(e => e.Source).HasColumnName("source");

            entity.HasOne(d => d.Book).WithMany(p => p.BooksSources)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksSources_Books");

            entity.HasOne(d => d.Language).WithMany(p => p.BooksSources)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksSources_Languages");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.ToTable("Library");

            entity.Property(e => e.LibraryId).HasColumnName("library_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Library_Users");
        });

        modelBuilder.Entity<LibraryBook>(entity =>
        {
            entity.HasKey(e => e.LibraryBooksId);

            entity.Property(e => e.LibraryBooksId).HasColumnName("library_books_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.LibraryId).HasColumnName("library_id");

            entity.HasOne(d => d.Book).WithMany(p => p.LibraryBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibraryBooks_Books1");

            entity.HasOne(d => d.Library).WithMany(p => p.LibraryBooks)
                .HasForeignKey(d => d.LibraryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LibraryBooks_Library1");
        });

        modelBuilder.Entity<LibraryView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("LibraryView");

            entity.Property(e => e.Author)
                .HasMaxLength(150)
                .HasColumnName("author");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
            entity.Property(e => e.LibraryBooksId).HasColumnName("library_books_id");
            entity.Property(e => e.LibraryId).HasColumnName("library_id");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ReaderDatum>(entity =>
        {
            entity.HasKey(e => e.ReaderDataId);

            entity.Property(e => e.ReaderDataId).HasColumnName("reader_data_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.CurrentPageNum).HasColumnName("current_page_num");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Book).WithMany(p => p.ReaderData)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReaderData_Books");

            entity.HasOne(d => d.User).WithMany(p => p.ReaderData)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReaderData_Users");
        });

        modelBuilder.Entity<ShowcaseView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ShowcaseView");

            entity.Property(e => e.BookId)
                .ValueGeneratedOnAdd()
                .HasColumnName("book_id");
            entity.Property(e => e.CoverImage).HasColumnName("cover_image");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CoverPhoto).HasColumnName("cover_photo");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasColumnName("phone");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Statuses");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
