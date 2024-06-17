using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public decimal Cost { get; set; }

    public int PageCount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public string Author { get; set; } = null!;

    public string CoverImage { get; set; } = null!;

    public int GenreId { get; set; }

    public virtual ICollection<BooksSource> BooksSources { get; set; } = new List<BooksSource>();

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<LibraryBook> LibraryBooks { get; set; } = new List<LibraryBook>();

    public virtual ICollection<ReaderDatum> ReaderData { get; set; } = new List<ReaderDatum>();
}
