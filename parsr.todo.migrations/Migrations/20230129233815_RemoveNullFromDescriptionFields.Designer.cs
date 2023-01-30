﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using parsr.todo.db;

#nullable disable

namespace parsr.todo.migrations.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    [Migration("20230129233815_RemoveNullFromDescriptionFields")]
    partial class RemoveNullFromDescriptionFields
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("parsr.todo.db.Models.TodoTask", b =>
                {
                    b.Property<int>("TodoTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoTaskId"));

                    b.Property<DateTime>("DateTimeCreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NewId()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(72)
                        .HasColumnType("nvarchar(72)");

                    b.Property<int>("TodoTaskListId")
                        .HasColumnType("int");

                    b.HasKey("TodoTaskId");

                    b.HasIndex("TodoTaskListId");

                    b.HasIndex(new[] { "PublicId" }, "UK_TodoTasks_PublicId")
                        .IsUnique();

                    b.ToTable("TodoTasks");
                });

            modelBuilder.Entity("parsr.todo.db.Models.TodoTaskList", b =>
                {
                    b.Property<int>("TodoTaskListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TodoTaskListId"));

                    b.Property<DateTime>("DateTimeCreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeUpdatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)");

                    b.Property<Guid>("PublicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NewId()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("TodoTaskListId");

                    b.HasIndex(new[] { "PublicId" }, "UK_TodoTaskLists_PublicId")
                        .IsUnique();

                    b.ToTable("TodoTaskLists");
                });

            modelBuilder.Entity("parsr.todo.db.Models.TodoTask", b =>
                {
                    b.HasOne("parsr.todo.db.Models.TodoTaskList", "TodoTaskList")
                        .WithMany("TodoTasks")
                        .HasForeignKey("TodoTaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TodoTaskList");
                });

            modelBuilder.Entity("parsr.todo.db.Models.TodoTaskList", b =>
                {
                    b.Navigation("TodoTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
