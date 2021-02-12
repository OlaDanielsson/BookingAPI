﻿// <auto-generated />
using System;
using BookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingAPI.Migrations
{
    [DbContext(typeof(BookingContext))]
    partial class BookingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BookingAPI.Models.BookingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingModel");
                });

            modelBuilder.Entity("BookingAPI.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Img")
                        .HasColumnType("BLOB");

                    b.Property<int>("NumberOfBeds")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Price")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CategoryModel");
                });

            modelBuilder.Entity("BookingAPI.Models.RoomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Floor")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("RoomModel");
                });

            modelBuilder.Entity("BookingAPI.Models.BookingModel", b =>
                {
                    b.HasOne("BookingAPI.Models.RoomModel", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BookingAPI.Models.RoomModel", b =>
                {
                    b.HasOne("BookingAPI.Models.CategoryModel", "Category")
                        .WithMany("RoomList")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookingAPI.Models.CategoryModel", b =>
                {
                    b.Navigation("RoomList");
                });
#pragma warning restore 612, 618
        }
    }
}