using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesignPattern;

public partial class MovieTicketSystemContext : DbContext
{
    public MovieTicketSystemContext()
    {
    }

    public MovieTicketSystemContext(DbContextOptions<MovieTicketSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Cinema> Cinemas { get; set; }

    public virtual DbSet<CinemaHall> CinemaHalls { get; set; }

    public virtual DbSet<CinemaSeat> CinemaSeats { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<ShowSeat> ShowSeats { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6UUU5I4\\SQLEXPRESS;Initial Catalog=Movie ticket system;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .ValueGeneratedNever()
                .HasColumnName("BookingID");
            entity.Property(e => e.ShowId).HasColumnName("ShowID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_User");
        });

        modelBuilder.Entity<Cinema>(entity =>
        {
            entity.ToTable("Cinema");

            entity.Property(e => e.CinemaId)
                .ValueGeneratedNever()
                .HasColumnName("CinemaID");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Cinemas)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cinema_City");
        });

        modelBuilder.Entity<CinemaHall>(entity =>
        {
            entity.HasKey(e => e.CinemaHallId).HasName("PK__Cinema_H__D212196095038DE1");

            entity.ToTable("Cinema_Hall");

            entity.Property(e => e.CinemaHallId)
                .ValueGeneratedNever()
                .HasColumnName("CinemaHallID");
            entity.Property(e => e.CinemaId).HasColumnName("CinemaID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Cinema).WithMany(p => p.CinemaHalls)
                .HasForeignKey(d => d.CinemaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cinema_Hall_Cinema");
        });

        modelBuilder.Entity<CinemaSeat>(entity =>
        {
            entity.ToTable("Cinema_Seat");

            entity.Property(e => e.CinemaSeatId)
                .ValueGeneratedNever()
                .HasColumnName("CinemaSeatID");
            entity.Property(e => e.CinemaHallId).HasColumnName("CinemaHallID");

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.CinemaSeats)
                .HasForeignKey(d => d.CinemaHallId)
                .HasConstraintName("FK_Cinema_Seat_Cinema_Hall");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.CityId)
                .ValueGeneratedNever()
                .HasColumnName("CityID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MoiveId);

            entity.ToTable("Movie");

            entity.Property(e => e.MoiveId).ValueGeneratedNever();
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descreption)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Duration)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Realeasedate)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.DiscountCouponId).HasColumnName("DiscountCouponID");
            entity.Property(e => e.RemoteTransactionId).HasColumnName("RemoteTransactionID");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payment_Booking");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.ToTable("Show");

            entity.Property(e => e.ShowId)
                .ValueGeneratedNever()
                .HasColumnName("Show_id");
            entity.Property(e => e.CinemaHallId).HasColumnName("Cinema_hall_id");
            entity.Property(e => e.Date)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MovieId).HasColumnName("Movie_id");
            entity.Property(e => e.StartTime)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CinemaHall).WithMany(p => p.Shows)
                .HasForeignKey(d => d.CinemaHallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Cinema_Hall");

            entity.HasOne(d => d.Movie).WithMany(p => p.Shows)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Movie");
        });

        modelBuilder.Entity<ShowSeat>(entity =>
        {
            entity.ToTable("Show_Seat");

            entity.Property(e => e.ShowSeatId)
                .ValueGeneratedNever()
                .HasColumnName("ShowSeatID");
            entity.Property(e => e.BookingId).HasColumnName("BookingID");
            entity.Property(e => e.CinemaSeatId).HasColumnName("CinemaSeatID");
            entity.Property(e => e.ShowId).HasColumnName("ShowID");

            entity.HasOne(d => d.Booking).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Seat_Booking");

            entity.HasOne(d => d.CinemaSeat).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.CinemaSeatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Seat_Cinema_Seat");

            entity.HasOne(d => d.Show).WithMany(p => p.ShowSeats)
                .HasForeignKey(d => d.ShowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Show_Seat_Show");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
