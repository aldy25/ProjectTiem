using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class RoomInventory
{
    public long Id { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string InventoryName { get; set; } = null!;

    public int Quantity { get; set; }

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
