﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Primpasso.Context;

namespace Primpasso.Migrations
{
    [DbContext(typeof(PrimpassoDbContext))]
    partial class PrimpassoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CandidateJobOpportunity", b =>
                {
                    b.Property<int>("CandidatesId")
                        .HasColumnType("int");

                    b.Property<int>("JobOpportunitiesId")
                        .HasColumnType("int");

                    b.HasKey("CandidatesId", "JobOpportunitiesId");

                    b.HasIndex("JobOpportunitiesId");

                    b.ToTable("CandidateJobOpportunity");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.Base.JobType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobType");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Candidate");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.JobOpportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("ClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JobTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobTypeId");

                    b.ToTable("JobOpportunity");
                });

            modelBuilder.Entity("CandidateJobOpportunity", b =>
                {
                    b.HasOne("Primpasso.Models.Entities.Candidate", null)
                        .WithMany()
                        .HasForeignKey("CandidatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Primpasso.Models.Entities.JobOpportunity", null)
                        .WithMany()
                        .HasForeignKey("JobOpportunitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Primpasso.Models.Entities.JobOpportunity", b =>
                {
                    b.HasOne("Primpasso.Models.Entities.Company", "Company")
                        .WithMany("JobsOpportunity")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Primpasso.Models.Entities.Base.JobType", "JobType")
                        .WithMany("JobOpportunities")
                        .HasForeignKey("JobTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("JobType");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.Base.JobType", b =>
                {
                    b.Navigation("JobOpportunities");
                });

            modelBuilder.Entity("Primpasso.Models.Entities.Company", b =>
                {
                    b.Navigation("JobsOpportunity");
                });
#pragma warning restore 612, 618
        }
    }
}