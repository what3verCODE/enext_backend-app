﻿// <auto-generated />
using System;
using Application.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiServer.Migrations
{
    [DbContext(typeof(ApiDataContext))]
    [Migration("20200611015002_QuestionTypeFix")]
    partial class QuestionTypeFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Domain.Entity.AchievementEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AchievementEntity");
                });

            modelBuilder.Entity("Domain.Entity.AnswerEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Domain.Entity.ClassEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Domain.Entity.CommentEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AuthorId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<long>("Likes")
                        .HasColumnType("bigint");

                    b.Property<long>("RootCommentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("WrittenAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("LessonId");

                    b.HasIndex("RootCommentId");

                    b.ToTable("CommentEntity");
                });

            modelBuilder.Entity("Domain.Entity.CourseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("Charge")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("Likes")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<string>("TargetAudience")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.AuthorCourseEntity", b =>
                {
                    b.Property<string>("AuthorId")
                        .HasColumnType("text");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.HasKey("AuthorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("AuthorCourseEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.CourseClassEntity", b =>
                {
                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.HasKey("ClassId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseClassEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.StudentClassEntity", b =>
                {
                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("StudentId")
                        .HasColumnType("text");

                    b.HasKey("ClassId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentClassEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.TeacherClassEntity", b =>
                {
                    b.Property<long>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<string>("TeacherId")
                        .HasColumnType("text");

                    b.HasKey("ClassId", "TeacherId");

                    b.HasIndex("ClassId")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherClassEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserAchievementsEntity", b =>
                {
                    b.Property<long>("AchievementId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("AchievementId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAchievementsEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCommentLikesEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<long>("CommentId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "CommentId");

                    b.HasIndex("CommentId");

                    b.ToTable("UserCommentLikesEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCourseEntity", b =>
                {
                    b.Property<string>("SubscriberId")
                        .HasColumnType("text");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.HasKey("SubscriberId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourseEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCourseLikesEntity", b =>
                {
                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("CourseId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourseLikesEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserLessonLikesEntity", b =>
                {
                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("LessonId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLessonLikesEntity");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserProgressEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("UserProgressEntity");
                });

            modelBuilder.Entity("Domain.Entity.LessonEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<long>("Likes")
                        .HasColumnType("bigint");

                    b.Property<bool>("ManualChecking")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long>("ModuleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("Domain.Entity.LessonSectionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<int>("MaxScore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Domain.Entity.ModuleEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Domain.Entity.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("OrganizationEntity");
                });

            modelBuilder.Entity("Domain.Entity.ProgressEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<bool>("ManualChecking")
                        .HasColumnType("boolean");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<long>("UserProgressCourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserProgressUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserProgressUserId", "UserProgressCourseId");

                    b.ToTable("ProgressEntity");
                });

            modelBuilder.Entity("Domain.Entity.QuestionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Score")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<long>("SectionId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Domain.Entity.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<int>("OrganizationId")
                        .HasColumnType("integer");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("OrganizationId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entity.AnswerEntity", b =>
                {
                    b.HasOne("Domain.Entity.QuestionEntity", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.CommentEntity", b =>
                {
                    b.HasOne("Domain.Entity.UserEntity", "Author")
                        .WithMany("Comments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.LessonEntity", "Lesson")
                        .WithMany("Comments")
                        .HasForeignKey("LessonId");

                    b.HasOne("Domain.Entity.CommentEntity", "RootComment")
                        .WithMany("Replies")
                        .HasForeignKey("RootCommentId");
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.AuthorCourseEntity", b =>
                {
                    b.HasOne("Domain.Entity.UserEntity", "Author")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany("Authors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.CourseClassEntity", b =>
                {
                    b.HasOne("Domain.Entity.ClassEntity", "Class")
                        .WithMany("Courses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.StudentClassEntity", b =>
                {
                    b.HasOne("Domain.Entity.ClassEntity", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "Student")
                        .WithMany("ClassesAsStudent")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.TeacherClassEntity", b =>
                {
                    b.HasOne("Domain.Entity.ClassEntity", "Class")
                        .WithOne("Teacher")
                        .HasForeignKey("Domain.Entity.Intermediate.TeacherClassEntity", "ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "Teacher")
                        .WithMany("ClassesAsTeacher")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserAchievementsEntity", b =>
                {
                    b.HasOne("Domain.Entity.AchievementEntity", "Achievement")
                        .WithMany("AchievementOwners")
                        .HasForeignKey("AchievementId");

                    b.HasOne("Domain.Entity.UserEntity", "User")
                        .WithMany("Achievements")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCommentLikesEntity", b =>
                {
                    b.HasOne("Domain.Entity.CommentEntity", "Comment")
                        .WithMany("UsersLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "User")
                        .WithMany("LikedComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCourseEntity", b =>
                {
                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany("Subscribers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "Subscriber")
                        .WithMany("Subscriptions")
                        .HasForeignKey("SubscriberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserCourseLikesEntity", b =>
                {
                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany("UsersLikes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "User")
                        .WithMany("LikedCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserLessonLikesEntity", b =>
                {
                    b.HasOne("Domain.Entity.LessonEntity", "Lesson")
                        .WithMany("UsersLikes")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "User")
                        .WithMany("LikedLessons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Intermediate.UserProgressEntity", b =>
                {
                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", "User")
                        .WithMany("Progresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.LessonEntity", b =>
                {
                    b.HasOne("Domain.Entity.ModuleEntity", "Module")
                        .WithMany("Lessons")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.LessonSectionEntity", b =>
                {
                    b.HasOne("Domain.Entity.LessonEntity", "Lesson")
                        .WithMany("Sections")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.ModuleEntity", b =>
                {
                    b.HasOne("Domain.Entity.CourseEntity", "Course")
                        .WithMany("Modules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.ProgressEntity", b =>
                {
                    b.HasOne("Domain.Entity.LessonEntity", "Lesson")
                        .WithMany("Progresses")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Intermediate.UserProgressEntity", "UserProgress")
                        .WithMany("Progresses")
                        .HasForeignKey("UserProgressUserId", "UserProgressCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.QuestionEntity", b =>
                {
                    b.HasOne("Domain.Entity.LessonSectionEntity", "Section")
                        .WithMany("Questions")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Domain.Entity.UserEntity", b =>
                {
                    b.HasOne("Domain.Entity.OrganizationEntity", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entity.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entity.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entity.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
