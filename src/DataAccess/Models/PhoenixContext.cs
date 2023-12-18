using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;

public partial class PhoenixContext : DbContext
{
    public PhoenixContext()
    {
    }

    public PhoenixContext(DbContextOptions<PhoenixContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomInventory> RoomInventories { get; set; }

    public virtual DbSet<RoomService> RoomServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Administ__F3DBC573D73B157F");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("job_title");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__Guests__F3DBC5733CD4CE30");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.Citizenship)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("citizenship");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.IdNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("id_number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationCode).HasName("PK__Reservat__FA8FADE5E7970C48");

            entity.Property(e => e.ReservationCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reservation_code");
            entity.Property(e => e.BookDate)
                .HasColumnType("datetime")
                .HasColumnName("book_date");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("check_out");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.GuestUsername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("guest_username");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.Remark)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("remark");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("room_number");

            entity.HasOne(d => d.GuestUsernameNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.GuestUsername)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__guest__30F848ED");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__room___300424B4");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Number).HasName("PK__Rooms__FD291E403DBE0CB1");

            entity.Property(e => e.Number)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("number");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Floor).HasColumnName("floor");
            entity.Property(e => e.GuestLimit).HasColumnName("guest_limit");
            entity.Property(e => e.RoomType)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("room_type");
        });

        modelBuilder.Entity<RoomInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomInve__3213E83FF8A9C44D");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.InventoryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("inventory_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("room_number");

            entity.HasOne(d => d.RoomNumberNavigation).WithMany(p => p.RoomInventories)
                .HasForeignKey(d => d.RoomNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomInven__room___2D27B809");
        });

        modelBuilder.Entity<RoomService>(entity =>
        {
            entity.HasKey(e => e.EmployeeNumber).HasName("PK__RoomServ__8C453B0CF8DD33BE");

            entity.Property(e => e.EmployeeNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("employee_number");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.FridayRosterFinish).HasColumnName("friday_roster_finish");
            entity.Property(e => e.FridayRosterStart).HasColumnName("friday_roster_start");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("middle_name");
            entity.Property(e => e.MondayRosterFinish).HasColumnName("monday_roster_finish");
            entity.Property(e => e.MondayRosterStart).HasColumnName("monday_roster_start");
            entity.Property(e => e.OutsourcingCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("outsourcing_company");
            entity.Property(e => e.SaturdayRosterFinish).HasColumnName("saturday_roster_finish");
            entity.Property(e => e.SaturdayRosterStart).HasColumnName("saturday_roster_start");
            entity.Property(e => e.SundayRosterFinish).HasColumnName("sunday_roster_finish");
            entity.Property(e => e.SundayRosterStart).HasColumnName("sunday_roster_start");
            entity.Property(e => e.ThursdayRosterFinish).HasColumnName("thursday_roster_finish");
            entity.Property(e => e.ThursdayRosterStart).HasColumnName("thursday_roster_start");
            entity.Property(e => e.TuesdayRosterFinish).HasColumnName("tuesday_roster_finish");
            entity.Property(e => e.TuesdayRosterStart).HasColumnName("tuesday_roster_start");
            entity.Property(e => e.WednesdayRosterFinish).HasColumnName("wednesday_roster_finish");
            entity.Property(e => e.WednesdayRosterStart).HasColumnName("wednesday_roster_start");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
