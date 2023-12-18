using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Reservation
{
    public string ReservationCode { get; set; } = null!;

    public string RoomNumber { get; set; } = null!;

    public string GuestUsername { get; set; } = null!;

    public DateTime BookDate { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public decimal Cost { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Remark { get; set; }

    public virtual Guest GuestUsernameNavigation { get; set; } = null!;

    public virtual Room RoomNumberNavigation { get; set; } = null!;
}
