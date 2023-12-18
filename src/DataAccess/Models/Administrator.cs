using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Administrator
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string JobTitle { get; set; } = null!;
}
