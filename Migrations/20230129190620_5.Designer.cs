﻿// <auto-generated />
using System;
using Instagram_Clone_Backend.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Instagram_Clone_Backend.Migrations
{
    [DbContext(typeof(InstagramCloneContext))]
    [Migration("20230129190620_5")]
    partial class _5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserComment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.CommentUserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CommentUserProfiles");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Comment", b =>
                {
                    b.HasOne("Instagram_Clone_Backend.Models.Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instagram_Clone_Backend.Models.UserProfile", null)
                        .WithMany("Comments")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Post", b =>
                {
                    b.HasOne("Instagram_Clone_Backend.Models.UserProfile", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Story", b =>
                {
                    b.HasOne("Instagram_Clone_Backend.Models.UserProfile", null)
                        .WithMany("Stories")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.UserProfile", b =>
                {
                    b.HasOne("Instagram_Clone_Backend.Models.User", null)
                        .WithOne("UserProfile")
                        .HasForeignKey("Instagram_Clone_Backend.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Like", b =>
                {
                    b.HasOne("Instagram_Clone_Backend.Models.Post", null)
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Instagram_Clone_Backend.Models.UserProfile", null)
                        .WithMany("Likes")
                        .HasForeignKey("UserProfileId");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.User", b =>
                {
                    b.Navigation("UserProfile")
                        .IsRequired();
                });

            modelBuilder.Entity("Instagram_Clone_Backend.Models.UserProfile", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Posts");

                    b.Navigation("Stories");
                });
#pragma warning restore 612, 618
        }
    }
}
