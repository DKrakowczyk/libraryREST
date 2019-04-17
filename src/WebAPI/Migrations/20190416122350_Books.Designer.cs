﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.DbContexts;

namespace WebAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20190416122350_Books")]
    partial class Books
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("WebAPI.Models.Book", b =>
                {
                    b.Property<long>("ISBN")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<long>("YEAR");

                    b.HasKey("ISBN");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
