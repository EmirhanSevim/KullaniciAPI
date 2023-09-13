﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SuperHeroAPI.Data;

#nullable disable

namespace KullanıcılarAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230908120413_denemee2")]
    partial class denemee2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KullanıcılarAPI.Models.Bookmark", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("categoryId")
                        .HasColumnType("integer");

                    b.Property<string>("created_at")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("userId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("KullanıcılarAPI.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KullanıcılarAPI.Models.userBookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("bookmarkId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserBookmark");
                });

            modelBuilder.Entity("KullanıcılarAPI.Models.userLike", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("bookmarkId")
                        .HasColumnType("integer");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UsersLike");
                });

            modelBuilder.Entity("SuperHeroAPI.Models.Kullanıcı", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("fullname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Kullanıcılar");
                });

            modelBuilder.Entity("KullanıcılarAPI.Models.Bookmark", b =>
                {
                    b.HasOne("KullanıcılarAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
