using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class User
{
    public int UserId { get; set; }

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public int StatusId { get; set; }

    public string? CoverPhoto { get; set; }

    public virtual ICollection<Library> Libraries { get; set; } = new List<Library>();

    public virtual ICollection<ReaderDatum> ReaderData { get; set; } = new List<ReaderDatum>();

    public virtual Status Status { get; set; } = null!;
}
