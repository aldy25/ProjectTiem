using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Room
{
    public string Number { get; set; } = null!;

    public int Floor { get; set; }

    public string RoomType { get; set; } = null!;

    public int GuestLimit { get; set; }

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<RoomInventory> RoomInventories { get; set; } = new List<RoomInventory>();
}
