﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDATA;

namespace SDATA.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200618223153_InitialCreateLite")]
    partial class InitialCreateLite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("SDomain.Value", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Value 101"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Value 102"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Value 103"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Value 104"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Value 105"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}