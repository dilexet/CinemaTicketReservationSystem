﻿// <auto-generated />
using System;
using CinemaTicketReservationSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CinemaTicketReservationSystem.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221104120924_InitDatabase")]
    partial class InitDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AddedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("boolean");

                    b.Property<string>("JwtId")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("67c40faf-c703-49e4-9837-a335e2c93fb2"),
                            Deleted = false,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("31868844-3d20-474f-a59a-8a072334f5cc"),
                            Deleted = false,
                            Name = "Manager"
                        },
                        new
                        {
                            Id = new Guid("f926108f-bba8-415f-aba4-afb1d1c1eceb"),
                            Deleted = false,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.AuthorizeEntity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("BookedOrders");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.BookingEntity.BookedService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookedOrderId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("NumberOfServices")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SessionAdditionalServiceId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("BookedOrderId");

                    b.HasIndex("SessionAdditionalServiceId");

                    b.ToTable("BookedService");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.AdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("AdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Latitude")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("SeatTypesString")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.CinemaEntity.Row", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

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
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<long>("NumberSeat")
                        .HasColumnType("bigint");

                    b.Property<Guid>("RowId")
                        .HasColumnType("uuid");

                    b.Property<string>("SeatType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PosterUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDescriptions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionAdditionalService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AdditionalServiceId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AdditionalServiceId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionAdditionalServices");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.SessionEntity.SessionSeat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BookedOrderId")
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SessionSeatTypeId")
                        .HasColumnType("uuid");

                    b.Property<int>("TicketState")
                        .HasColumnType("integer");

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
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("SeatTypeName")
                        .HasColumnType("text");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionSeatTypes");
                });

            modelBuilder.Entity("CinemaTicketReservationSystem.DAL.Entity.UserEntity.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("CountryMovieDescription", b =>
                {
                    b.Property<Guid>("CountriesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieDescriptionsId")
                        .HasColumnType("uuid");

                    b.HasKey("CountriesId", "MovieDescriptionsId");

                    b.HasIndex("MovieDescriptionsId");

                    b.ToTable("CountryMovieDescription");
                });

            modelBuilder.Entity("GenreMovieDescription", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieDescriptionsId")
                        .HasColumnType("uuid");

                    b.HasKey("GenresId", "MovieDescriptionsId");

                    b.HasIndex("MovieDescriptionsId");

                    b.ToTable("GenreMovieDescription");
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

            modelBuilder.Entity("CountryMovieDescription", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Country", null)
                        .WithMany()
                        .HasForeignKey("CountriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", null)
                        .WithMany()
                        .HasForeignKey("MovieDescriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreMovieDescription", b =>
                {
                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CinemaTicketReservationSystem.DAL.Entity.MovieEntity.MovieDescription", null)
                        .WithMany()
                        .HasForeignKey("MovieDescriptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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