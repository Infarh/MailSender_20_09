﻿// <auto-generated />
using System;
using MailSender.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MailSender.Data.Migrations
{
    [DbContext(typeof(MailSenderDB))]
    [Migration("20201016161251_NameRequired")]
    partial class NameRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MailSender.lib.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MailSender.lib.Models.Recipient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchedulerTaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SchedulerTaskId");

                    b.ToTable("Recipients");
                });

            modelBuilder.Entity("MailSender.lib.Models.SchedulerTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MessageId")
                        .HasColumnType("int");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<int?>("ServerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MessageId");

                    b.HasIndex("SenderId");

                    b.HasIndex("ServerId");

                    b.ToTable("SchedulerTasks");
                });

            modelBuilder.Entity("MailSender.lib.Models.Sender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Senders");
                });

            modelBuilder.Entity("MailSender.lib.Models.Server", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<bool>("UseSSL")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("MailSender.lib.Models.Recipient", b =>
                {
                    b.HasOne("MailSender.lib.Models.SchedulerTask", null)
                        .WithMany("Recipients")
                        .HasForeignKey("SchedulerTaskId");
                });

            modelBuilder.Entity("MailSender.lib.Models.SchedulerTask", b =>
                {
                    b.HasOne("MailSender.lib.Models.Message", "Message")
                        .WithMany()
                        .HasForeignKey("MessageId");

                    b.HasOne("MailSender.lib.Models.Sender", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("MailSender.lib.Models.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId");
                });
#pragma warning restore 612, 618
        }
    }
}
