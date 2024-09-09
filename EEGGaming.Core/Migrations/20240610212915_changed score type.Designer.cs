﻿// <auto-generated />
using System;
using EEGGaming.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EEGGaming.Core.Migrations
{
    [DbContext(typeof(EEGGamingDbContext))]
    [Migration("20240610212915_changed score type")]
    partial class changedscoretype
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("EEGGaming.Core.Data.Models.BrainwavesRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Alpha1_Rel_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Alpha1_Rel_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Alpha1_Rel_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Alpha1_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Alpha1_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Alpha1_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_Rel_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_Rel_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_Rel_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Beta1_ch2")
                        .HasColumnType("REAL");

                    b.Property<bool>("Blinked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Delta_Rel_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Delta_Rel_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Delta_Rel_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Delta_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Delta_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Delta_ch2")
                        .HasColumnType("REAL");

                    b.Property<int>("GamingSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Gamma1_Rel_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Gamma1_Rel_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Gamma1_Rel_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Gamma1_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Gamma1_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Gamma1_ch2")
                        .HasColumnType("REAL");

                    b.Property<byte>("Marker")
                        .HasColumnType("INTEGER");

                    b.Property<double>("MiliSecond")
                        .HasColumnType("REAL");

                    b.Property<uint>("PackNumber")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Second")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_Rel_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_Rel_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_Rel_ch2")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_avgch")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_ch1")
                        .HasColumnType("REAL");

                    b.Property<double>("Theta_ch2")
                        .HasColumnType("REAL");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BrainWaves");
                });

            modelBuilder.Entity("EEGGaming.Core.Data.Models.GamingSesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<double>("Score")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<int>("User")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("GameSession");
                });

            modelBuilder.Entity("EEGGaming.Core.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
