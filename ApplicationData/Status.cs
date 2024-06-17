using System;
using System.Collections.Generic;

namespace Backend_LeLire.ApplicationData;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
