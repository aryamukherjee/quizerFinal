﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Quizer.Models;
using System;

namespace Quizer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180422224935_addGrades")]
    partial class addGrades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Quizer.Models.CompletedQuiz", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MCQAnswer");

                    b.Property<int?>("QuestionID");

                    b.Property<int?>("QuizID");

                    b.Property<string>("TextAnswer");

                    b.HasKey("ID");

                    b.HasIndex("QuestionID");

                    b.HasIndex("QuizID");

                    b.ToTable("CompletedQuizes");
                });

            modelBuilder.Entity("Quizer.Models.Grade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FinalGrade");

                    b.Property<int?>("InitialGrade");

                    b.Property<int?>("QuizID");

                    b.HasKey("ID");

                    b.HasIndex("QuizID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Quizer.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CorrectAnswer");

                    b.Property<string>("MCQAnswer1");

                    b.Property<string>("MCQAnswer2");

                    b.Property<string>("MCQAnswer3");

                    b.Property<string>("MCQAnswer4");

                    b.Property<int>("Points");

                    b.Property<string>("QuestionText");

                    b.Property<string>("QuestionType");

                    b.Property<int>("QuizID");

                    b.Property<int>("SelectedAnswer");

                    b.Property<string>("TextAnswer");

                    b.HasKey("QuestionID");

                    b.HasIndex("QuizID");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Quizer.Models.Quiz", b =>
                {
                    b.Property<int>("QuizID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Title");

                    b.Property<int>("TotalPoints");

                    b.HasKey("QuizID");

                    b.ToTable("Quizes");
                });

            modelBuilder.Entity("Quizer.Models.CompletedQuiz", b =>
                {
                    b.HasOne("Quizer.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionID");

                    b.HasOne("Quizer.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizID");
                });

            modelBuilder.Entity("Quizer.Models.Grade", b =>
                {
                    b.HasOne("Quizer.Models.Quiz", "Quiz")
                        .WithMany()
                        .HasForeignKey("QuizID");
                });

            modelBuilder.Entity("Quizer.Models.Question", b =>
                {
                    b.HasOne("Quizer.Models.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
