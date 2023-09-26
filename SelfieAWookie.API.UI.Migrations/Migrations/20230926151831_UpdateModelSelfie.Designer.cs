﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SelfieAWookie.Core.Selfies.Infrastructure.DataBase;

#nullable disable

namespace SelfieAWookie.API.UI.Migrations.Migrations
{
    [DbContext(typeof(SelfieDbContext))]
    [Migration("20230926151831_UpdateModelSelfie")]
    partial class UpdateModelSelfie
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Images", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Selfie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ImageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("WookieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("WookieId");

                    b.ToTable("Selfie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:Identity", "1, 1");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(155)
                        .HasColumnType("nvarchar(155)");

                    b.HasKey("Id");

                    b.ToTable("Wookie", (string)null);
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Selfie", b =>
                {
                    b.HasOne("SelfieAWookie.Core.Selfies.Domain.Image", "Image")
                        .WithMany("Selfies")
                        .HasForeignKey("ImageId");

                    b.HasOne("SelfieAWookie.Core.Selfies.Domain.Wookie", "Wookie")
                        .WithMany("Selfies")
                        .HasForeignKey("WookieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Wookie");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Image", b =>
                {
                    b.Navigation("Selfies");
                });

            modelBuilder.Entity("SelfieAWookie.Core.Selfies.Domain.Wookie", b =>
                {
                    b.Navigation("Selfies");
                });
#pragma warning restore 612, 618
        }
    }
}
