﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlanetaSingli.API.Data;

namespace PlanetaSingli.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("PlanetaSingli.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PlanetaSingli.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Children")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Education")
                        .HasColumnType("TEXT");

                    b.Property<string>("EyeColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("FreeTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("FriendsWouldDescribeMe")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("Growth")
                        .HasColumnType("TEXT");

                    b.Property<string>("HairColor")
                        .HasColumnType("TEXT");

                    b.Property<string>("ILike")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdoNotLike")
                        .HasColumnType("TEXT");

                    b.Property<string>("Interests")
                        .HasColumnType("TEXT");

                    b.Property<string>("ItFeelsBestIn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Languages")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastActive")
                        .HasColumnType("TEXT");

                    b.Property<string>("LookingFor")
                        .HasColumnType("TEXT");

                    b.Property<string>("MakesMeLaugh")
                        .HasColumnType("TEXT");

                    b.Property<string>("MartialStatus")
                        .HasColumnType("TEXT");

                    b.Property<string>("Motto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Movies")
                        .HasColumnType("TEXT");

                    b.Property<string>("Music")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordRaw")
                        .HasColumnType("BLOB");

                    b.Property<string>("Personality")
                        .HasColumnType("TEXT");

                    b.Property<string>("Profession")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sport")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZodiacSign")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlanetaSingli.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Name")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("PlanetaSingli.API.Models.Photo", b =>
                {
                    b.HasOne("PlanetaSingli.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
