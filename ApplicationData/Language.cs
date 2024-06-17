using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class Language
{
    public int LanguageId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BooksSource> BooksSources { get; set; } = new List<BooksSource>();
}
