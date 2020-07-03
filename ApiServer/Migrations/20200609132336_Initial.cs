using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AchievementEntity",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_AchievementEntity", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "Classes",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    TeacherId = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Classes", x => x.Id); });

            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    TargetAudience = table.Column<string>(nullable: true),
                    Charge = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Likes = table.Column<long>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Courses", x => x.Id); });

            migrationBuilder.CreateTable(
                "OrganizationEntity",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_OrganizationEntity", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CourseClassEntity",
                table => new
                {
                    CourseId = table.Column<long>(nullable: false),
                    ClassId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseClassEntity", x => new {x.ClassId, x.CourseId});
                    table.ForeignKey(
                        "FK_CourseClassEntity_Classes_ClassId",
                        x => x.ClassId,
                        "Classes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CourseClassEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Modules",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastModifiedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    CourseId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        "FK_Modules_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUsers_OrganizationEntity_OrganizationId",
                        x => x.OrganizationId,
                        "OrganizationEntity",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Lessons",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastModifiedBy = table.Column<string>(nullable: false),
                    LastModifiedAt = table.Column<DateTime>(nullable: false),
                    ModuleId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    ManualChecking = table.Column<bool>(nullable: false, defaultValue: false),
                    Likes = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        "FK_Lessons_Modules_ModuleId",
                        x => x.ModuleId,
                        "Modules",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AuthorCourseEntity",
                table => new
                {
                    AuthorId = table.Column<string>(nullable: false),
                    CourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorCourseEntity", x => new {x.AuthorId, x.CourseId});
                    table.ForeignKey(
                        "FK_AuthorCourseEntity_AspNetUsers_AuthorId",
                        x => x.AuthorId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AuthorCourseEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "StudentClassEntity",
                table => new
                {
                    StudentId = table.Column<string>(nullable: false),
                    ClassId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClassEntity", x => new {x.ClassId, x.StudentId});
                    table.ForeignKey(
                        "FK_StudentClassEntity_Classes_ClassId",
                        x => x.ClassId,
                        "Classes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_StudentClassEntity_AspNetUsers_StudentId",
                        x => x.StudentId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TeacherClassEntity",
                table => new
                {
                    TeacherId = table.Column<string>(nullable: false),
                    ClassId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClassEntity", x => new {x.ClassId, x.TeacherId});
                    table.ForeignKey(
                        "FK_TeacherClassEntity_Classes_ClassId",
                        x => x.ClassId,
                        "Classes",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TeacherClassEntity_AspNetUsers_TeacherId",
                        x => x.TeacherId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserAchievementsEntity",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    AchievementId = table.Column<long>(nullable: false),
                    ReceivedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievementsEntity", x => new {x.AchievementId, x.UserId});
                    table.ForeignKey(
                        "FK_UserAchievementsEntity_AchievementEntity_AchievementId",
                        x => x.AchievementId,
                        "AchievementEntity",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_UserAchievementsEntity_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserCourseEntity",
                table => new
                {
                    SubscriberId = table.Column<string>(nullable: false),
                    CourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseEntity", x => new {x.SubscriberId, x.CourseId});
                    table.ForeignKey(
                        "FK_UserCourseEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserCourseEntity_AspNetUsers_SubscriberId",
                        x => x.SubscriberId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserCourseLikesEntity",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourseLikesEntity", x => new {x.CourseId, x.UserId});
                    table.ForeignKey(
                        "FK_UserCourseLikesEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserCourseLikesEntity_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserProgressEntity",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProgressEntity", x => new {x.UserId, x.CourseId});
                    table.ForeignKey(
                        "FK_UserProgressEntity_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserProgressEntity_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CommentEntity",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<string>(nullable: false),
                    RootCommentId = table.Column<long>(nullable: false),
                    LessonId = table.Column<long>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    WrittenAt = table.Column<DateTime>(nullable: false),
                    Likes = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEntity", x => x.Id);
                    table.ForeignKey(
                        "FK_CommentEntity_AspNetUsers_AuthorId",
                        x => x.AuthorId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CommentEntity_Lessons_LessonId",
                        x => x.LessonId,
                        "Lessons",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_CommentEntity_CommentEntity_RootCommentId",
                        x => x.RootCommentId,
                        "CommentEntity",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "Sections",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    VideoUrl = table.Column<string>(nullable: true),
                    MaxScore = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        "FK_Sections_Lessons_LessonId",
                        x => x.LessonId,
                        "Lessons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserLessonLikesEntity",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LessonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLessonLikesEntity", x => new {x.LessonId, x.UserId});
                    table.ForeignKey(
                        "FK_UserLessonLikesEntity_Lessons_LessonId",
                        x => x.LessonId,
                        "Lessons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserLessonLikesEntity_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "ProgressEntity",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LessonId = table.Column<long>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    ManualChecking = table.Column<bool>(nullable: false),
                    UserProgressUserId = table.Column<string>(nullable: false),
                    UserProgressCourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressEntity", x => x.Id);
                    table.ForeignKey(
                        "FK_ProgressEntity_Lessons_LessonId",
                        x => x.LessonId,
                        "Lessons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_ProgressEntity_UserProgressEntity_UserProgressUserId_UserPr~",
                        x => new {x.UserProgressUserId, x.UserProgressCourseId},
                        "UserProgressEntity",
                        new[] {"UserId", "CourseId"},
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "UserCommentLikesEntity",
                table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    CommentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCommentLikesEntity", x => new {x.UserId, x.CommentId});
                    table.ForeignKey(
                        "FK_UserCommentLikesEntity_CommentEntity_CommentId",
                        x => x.CommentId,
                        "CommentEntity",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_UserCommentLikesEntity_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "QuestionEntity",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SectionId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Score = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionEntity", x => x.Id);
                    table.ForeignKey(
                        "FK_QuestionEntity_Sections_SectionId",
                        x => x.SectionId,
                        "Sections",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "AnswerEntity",
                table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionId = table.Column<long>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    IsCorrect = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerEntity", x => x.Id);
                    table.ForeignKey(
                        "FK_AnswerEntity_QuestionEntity_QuestionId",
                        x => x.QuestionId,
                        "QuestionEntity",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_AnswerEntity_QuestionId",
                "AnswerEntity",
                "QuestionId");

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUsers_OrganizationId",
                "AspNetUsers",
                "OrganizationId");

            migrationBuilder.CreateIndex(
                "IX_AuthorCourseEntity_CourseId",
                "AuthorCourseEntity",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_CommentEntity_AuthorId",
                "CommentEntity",
                "AuthorId");

            migrationBuilder.CreateIndex(
                "IX_CommentEntity_LessonId",
                "CommentEntity",
                "LessonId");

            migrationBuilder.CreateIndex(
                "IX_CommentEntity_RootCommentId",
                "CommentEntity",
                "RootCommentId");

            migrationBuilder.CreateIndex(
                "IX_CourseClassEntity_CourseId",
                "CourseClassEntity",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_Lessons_ModuleId",
                "Lessons",
                "ModuleId");

            migrationBuilder.CreateIndex(
                "IX_Modules_CourseId",
                "Modules",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_ProgressEntity_LessonId",
                "ProgressEntity",
                "LessonId");

            migrationBuilder.CreateIndex(
                "IX_ProgressEntity_UserProgressUserId_UserProgressCourseId",
                "ProgressEntity",
                new[] {"UserProgressUserId", "UserProgressCourseId"});

            migrationBuilder.CreateIndex(
                "IX_QuestionEntity_SectionId",
                "QuestionEntity",
                "SectionId");

            migrationBuilder.CreateIndex(
                "IX_Sections_LessonId",
                "Sections",
                "LessonId");

            migrationBuilder.CreateIndex(
                "IX_StudentClassEntity_StudentId",
                "StudentClassEntity",
                "StudentId");

            migrationBuilder.CreateIndex(
                "IX_TeacherClassEntity_ClassId",
                "TeacherClassEntity",
                "ClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_TeacherClassEntity_TeacherId",
                "TeacherClassEntity",
                "TeacherId");

            migrationBuilder.CreateIndex(
                "IX_UserAchievementsEntity_UserId",
                "UserAchievementsEntity",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserCommentLikesEntity_CommentId",
                "UserCommentLikesEntity",
                "CommentId");

            migrationBuilder.CreateIndex(
                "IX_UserCourseEntity_CourseId",
                "UserCourseEntity",
                "CourseId");

            migrationBuilder.CreateIndex(
                "IX_UserCourseLikesEntity_UserId",
                "UserCourseLikesEntity",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserLessonLikesEntity_UserId",
                "UserLessonLikesEntity",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_UserProgressEntity_CourseId",
                "UserProgressEntity",
                "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AnswerEntity");

            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "AuthorCourseEntity");

            migrationBuilder.DropTable(
                "CourseClassEntity");

            migrationBuilder.DropTable(
                "ProgressEntity");

            migrationBuilder.DropTable(
                "StudentClassEntity");

            migrationBuilder.DropTable(
                "TeacherClassEntity");

            migrationBuilder.DropTable(
                "UserAchievementsEntity");

            migrationBuilder.DropTable(
                "UserCommentLikesEntity");

            migrationBuilder.DropTable(
                "UserCourseEntity");

            migrationBuilder.DropTable(
                "UserCourseLikesEntity");

            migrationBuilder.DropTable(
                "UserLessonLikesEntity");

            migrationBuilder.DropTable(
                "QuestionEntity");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "UserProgressEntity");

            migrationBuilder.DropTable(
                "Classes");

            migrationBuilder.DropTable(
                "AchievementEntity");

            migrationBuilder.DropTable(
                "CommentEntity");

            migrationBuilder.DropTable(
                "Sections");

            migrationBuilder.DropTable(
                "AspNetUsers");

            migrationBuilder.DropTable(
                "Lessons");

            migrationBuilder.DropTable(
                "OrganizationEntity");

            migrationBuilder.DropTable(
                "Modules");

            migrationBuilder.DropTable(
                "Courses");
        }
    }
}