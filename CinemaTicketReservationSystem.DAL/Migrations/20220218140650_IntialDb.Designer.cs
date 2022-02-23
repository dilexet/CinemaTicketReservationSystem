﻿// <auto-generated />

using System;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220218140650_IntialDb")]
    partial class IntialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("JwtId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6cac603f-c091-40c7-a4c6-43924d59fc4e"),
                            Deleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("624f28f8-f2fa-4141-8041-2d61480c330b"),
                            Deleted = false,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = new Guid("72d25f28-75cd-4a96-81a2-b07a54a69e94"),
                            Deleted = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("BookedOrders");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookedOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long>("NumberOfServices")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SessionAdditionalServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookedOrderId");

                    b.HasIndex("SessionAdditionalServiceId");

                    b.ToTable("BookedService");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.AdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("NumberOfRows")
                        .HasColumnType("bigint");

                    b.Property<string>("SeatTypesString")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Row", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("NumberOfSeats")
                        .HasColumnType("bigint");

                    b.Property<long>("NumberRow")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<long>("NumberSeat")
                        .HasColumnType("bigint");

                    b.Property<Guid>("RowId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountriesString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Countries");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenresString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Genres");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDescriptions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionAdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AdditionalServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalServiceId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionAdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BookedOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionSeatTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketState")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookedOrderId");

                    b.HasIndex("SeatId");

                    b.HasIndex("SessionId");

                    b.HasIndex("SessionSeatTypeId");

                    b.ToTable("SessionSeats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeatType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SeatType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionSeatTypes");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.RefreshToken", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", "UserProfile")
                        .WithMany("Tickets")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedService", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", "BookedOrder")
                        .WithMany("SelectedAdditionalServices")
                        .HasForeignKey("BookedOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionAdditionalService", "SelectedSessionAdditionalService")
                        .WithMany("BookedServices")
                        .HasForeignKey("SessionAdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookedOrder");

                    b.Navigation("SelectedSessionAdditionalService");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.AdditionalService", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", "Cinema")
                        .WithMany("AdditionalServices")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Address", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", "Cinema")
                        .WithOne("Address")
                        .HasForeignKey("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Address", "CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", "Cinema")
                        .WithMany("Halls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Row", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", "Hall")
                        .WithMany("Rows")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Seat", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Row", "Row")
                        .WithMany("Seats")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Row");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Movie", "Movie")
                        .WithOne("MovieDescription")
                        .HasForeignKey("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionAdditionalService", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.AdditionalService", "AdditionalService")
                        .WithMany("SessionAdditionalServices")
                        .HasForeignKey("AdditionalServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", "Session")
                        .WithMany("SessionAdditionalServices")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AdditionalService");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeat", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", "BookedOrder")
                        .WithMany("ReservedSessionSeats")
                        .HasForeignKey("BookedOrderId");

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Seat", "Seat")
                        .WithMany("SessionSeats")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", "Session")
                        .WithMany("SessionSeats")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeatType", "SessionSeatType")
                        .WithMany("SessionSeats")
                        .HasForeignKey("SessionSeatTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BookedOrder");

                    b.Navigation("Seat");

                    b.Navigation("Session");

                    b.Navigation("SessionSeatType");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeatType", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", "Session")
                        .WithMany("SessionSeatType")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", b =>
                {
                    b.Navigation("ReservedSessionSeats");

                    b.Navigation("SelectedAdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.AdditionalService", b =>
                {
                    b.Navigation("SessionAdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", b =>
                {
                    b.Navigation("AdditionalServices");

                    b.Navigation("Address");

                    b.Navigation("Halls");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", b =>
                {
                    b.Navigation("Rows");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Row", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Seat", b =>
                {
                    b.Navigation("SessionSeats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Movie", b =>
                {
                    b.Navigation("MovieDescription");

                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", b =>
                {
                    b.Navigation("SessionAdditionalServices");

                    b.Navigation("SessionSeats");

                    b.Navigation("SessionSeatType");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionAdditionalService", b =>
                {
                    b.Navigation("BookedServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeatType", b =>
                {
                    b.Navigation("SessionSeats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
