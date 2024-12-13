using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace data;

public partial class AirlineContext : DbContext
{
    public AirlineContext()
    {
    }

    public AirlineContext(DbContextOptions<AirlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Passanger> Passangers { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DERICKS_COMP\\MYDB;Database=airline;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.ToTable("flights");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArrivalAirport)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("arrivalAirport");
            entity.Property(e => e.ArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("arrivalTime");
            entity.Property(e => e.AvailableSeats).HasColumnName("availableSeats");
            entity.Property(e => e.DepartureTime)
                .HasColumnType("datetime")
                .HasColumnName("departureTime");
            entity.Property(e => e.FlightNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("flightNumber");
        });

        modelBuilder.Entity<Passanger>(entity =>
        {
            entity.ToTable("passangers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("reservations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.FlightId).HasColumnName("flight_id");
            entity.Property(e => e.PassangerId).HasColumnName("passangerId");
            entity.Property(e => e.ReservationDate)
                .HasColumnType("datetime")
                .HasColumnName("reservationDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
