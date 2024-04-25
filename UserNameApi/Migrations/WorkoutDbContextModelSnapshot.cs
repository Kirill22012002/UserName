﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserNameApi;

#nullable disable

namespace UserNameApi.Migrations
{
    [DbContext(typeof(WorkoutDbContext))]
    partial class WorkoutDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserNameApi.Models.DbModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.Workout", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EndDate")
                        .HasColumnType("bigint");

                    b.Property<long>("StartDate")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutExcercise", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkoutExcercises");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("WorkoutExcerciseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("WorkoutId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutExcerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutSessions");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutSet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<long?>("WorkoutSessionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutSessionId");

                    b.ToTable("WorkoutSets");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutSession", b =>
                {
                    b.HasOne("UserNameApi.Models.DbModels.WorkoutExcercise", "WorkoutExcercise")
                        .WithMany()
                        .HasForeignKey("WorkoutExcerciseId");

                    b.HasOne("UserNameApi.Models.DbModels.Workout", null)
                        .WithMany("WorkoutSessions")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("WorkoutExcercise");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutSet", b =>
                {
                    b.HasOne("UserNameApi.Models.DbModels.WorkoutSession", null)
                        .WithMany("WorkoutSets")
                        .HasForeignKey("WorkoutSessionId");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.Workout", b =>
                {
                    b.Navigation("WorkoutSessions");
                });

            modelBuilder.Entity("UserNameApi.Models.DbModels.WorkoutSession", b =>
                {
                    b.Navigation("WorkoutSets");
                });
#pragma warning restore 612, 618
        }
    }
}
