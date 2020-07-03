using Domain.Entity;
using Domain.Entity.Common;
using Domain.Entity.Intermediate;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence
{
    public static class ApiDataContextConfiguration
    {
        public static void ConfigureIntermediate(this ModelBuilder builder)
        {
            builder.Entity<AuthorCourseEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.AuthorId, x.CourseId});

                entity.HasOne(x => x.Author)
                    .WithMany(y => y.CreatedCourses)
                    .HasForeignKey(x => x.AuthorId);

                entity.HasOne(x => x.Course)
                    .WithMany(y => y.Authors)
                    .HasForeignKey(x => x.CourseId);
            });

            builder.Entity<CourseClassEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.ClassId, x.CourseId});

                entity
                    .HasOne(x => x.Course)
                    .WithMany(y => y.Classes)
                    .HasForeignKey(x => x.CourseId);

                entity
                    .HasOne(x => x.Class)
                    .WithMany(y => y.Courses)
                    .HasForeignKey(x => x.ClassId);
            });

            builder.Entity<StudentClassEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.ClassId, x.StudentId});

                entity
                    .HasOne(x => x.Class)
                    .WithMany(y => y.Students)
                    .HasForeignKey(x => x.ClassId);

                entity
                    .HasOne(x => x.Student)
                    .WithMany(y => y.ClassesAsStudent)
                    .HasForeignKey(x => x.StudentId);
            });
            
            builder.Entity<TeacherClassEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.ClassId, x.TeacherId});

                entity
                    .HasOne(x => x.Class)
                    .WithOne(y => y.Teacher)
                    .HasForeignKey<TeacherClassEntity>(x => x.ClassId);

                entity
                    .HasOne(x => x.Teacher)
                    .WithMany(y => y.ClassesAsTeacher)
                    .HasForeignKey(x => x.TeacherId);
            });
            
            builder.Entity<UserAchievementsEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.AchievementId, x.UserId});

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.Achievements)
                    .HasForeignKey(x => x.UserId);

                entity
                    .HasOne(x => x.Achievement)
                    .WithMany(y => y.AchievementOwners)
                    .HasForeignKey(x => x.AchievementId);
            });
            
            builder.Entity<UserCommentLikesEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.UserId, x.CommentId});

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.LikedComments)
                    .HasForeignKey(x => x.UserId);

                entity
                    .HasOne(x => x.Comment)
                    .WithMany(y => y.UsersLikes)
                    .HasForeignKey(x => x.CommentId);
            });
            
            builder.Entity<UserCourseEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.SubscriberId, x.CourseId});

                entity
                    .HasOne(x => x.Subscriber)
                    .WithMany(y => y.Subscriptions)
                    .HasForeignKey(x => x.SubscriberId);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(y => y.Subscribers)
                    .HasForeignKey(x => x.CourseId);
            });
            
            builder.Entity<UserCourseLikesEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.CourseId, x.UserId});

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.LikedCourses)
                    .HasForeignKey(x => x.UserId);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(y => y.UsersLikes)
                    .HasForeignKey(x => x.CourseId);
            });
            
            builder.Entity<UserLessonLikesEntity>(entity =>
            {
                entity
                    .HasKey(x => new {x.LessonId, x.UserId});

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.LikedLessons)
                    .HasForeignKey(x => x.UserId);

                entity
                    .HasOne(x => x.Lesson)
                    .WithMany(y => y.UsersLikes)
                    .HasForeignKey(x => x.LessonId);
            });


            builder.Entity<LastVisitedLessonEntity>(entity =>
            {
                entity.HasKey(x => new {x.UserId, x.CourseId});
            });
        }
        public static void Configure(this ModelBuilder builder)
        {
            builder.Entity<RefreshTokenEntity>(entity =>
            {
                entity.HasKey(x => x.Token);
            });
            builder.Entity<UserEntity>(entity =>
            {
                entity.Property(x => x.FirstName).IsRequired(false);
                entity.Property(x => x.MiddleName).IsRequired(false);
                entity.Property(x => x.LastName).IsRequired(false);
                entity.Property(x => x.Bio).IsRequired(false);
                entity.Property(x => x.Avatar).IsRequired(false);

                entity
                    .HasOne(x => x.Organization)
                    .WithMany(y => y.Users)
                    .HasForeignKey(x => x.OrganizationId)
                    .IsRequired(false);
            });

            builder.Entity<CourseEntity>(entity =>
            {
                entity.Property(x => x.Description).IsRequired(false);
                entity.Property(x => x.ShortDescription).IsRequired(false);
                entity.Property(x => x.TargetAudience).IsRequired(false);
                entity.Property(x => x.Charge).IsRequired(false);
                entity.Property(x => x.Avatar).IsRequired(false);
                
                //for dev
                entity.Property(x => x.LastModifiedBy).IsRequired(false);

                entity
                    .HasMany(x => x.Modules)
                    .WithOne(y => y.Course);
            });

            builder.Entity<ModuleEntity>(entity =>
            {
                //for dev
                entity.Property(x => x.LastModifiedBy).IsRequired(false);
                
                entity
                    .HasMany(x => x.Lessons)
                    .WithOne(y => y.Module);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(y => y.Modules)
                    .HasForeignKey(x => x.CourseId);
            });

            builder.Entity<LessonEntity>(entity =>
            {
                //for dev
                entity.Property(x => x.LastModifiedBy).IsRequired(false);

                entity.Property(x => x.MaxScore).HasDefaultValue(0);
                
                entity
                    .Property(x => x.ManualChecking)
                    .HasDefaultValue(false);

                entity
                    .HasMany(x => x.Sections)
                    .WithOne(y => y.Lesson)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasMany(x => x.Comments)
                    .WithOne(y => y.Lesson);

                entity
                    .HasMany(x => x.UsersLikes)
                    .WithOne(y => y.Lesson);

                entity
                    .HasOne(x => x.Module)
                    .WithMany(y => y.Lessons)
                    .HasForeignKey(x => x.ModuleId);
            });

            builder.Entity<LessonSectionEntity>(entity =>
            {
                entity.Property(x => x.Text).IsRequired(false);
                entity.Property(x => x.VideoUrl).IsRequired(false);

                entity
                    .HasOne(x => x.Quiz)
                    .WithOne(y => y.Section)
                    .HasForeignKey<LessonSectionEntity>(x => x.QuizId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasOne(x => x.Lesson)
                    .WithMany(y => y.Sections)
                    .HasForeignKey(x => x.LessonId);
            });

            builder.Entity<QuizEntity>(entity =>
            {
                entity
                    .HasOne(x => x.Section)
                    .WithOne(y => y.Quiz)
                    .HasForeignKey<QuizEntity>(x => x.SectionId)
                    .IsRequired(true);

                entity
                    .HasMany(x => x.Questions)
                    .WithOne(y => y.Quiz)
                    .IsRequired(false);
            });

            builder.Entity<QuizAttempts>(entity =>
            {
                entity.HasKey(x => new {x.AttemptId, x.ProgressId, x.UserId, x.QuizId});
                
                entity
                    .HasOne(x => x.Progress)
                    .WithMany(y => y.Attempts);

                entity
                    .HasOne(x => x.Quiz)
                    .WithMany(y => y.Attempts);

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.QuizAttempts);
            });

            builder.Entity<QuestionEntity>(entity =>
            {
                entity.Property(x => x.Value).IsRequired(true);
                entity.Property(x => x.Score).HasDefaultValue(0);

                entity
                    .HasOne(x => x.Quiz)
                    .WithMany(y => y.Questions)
                    .HasForeignKey(x => x.QuizId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                    .HasMany(x => x.Answers)
                    .WithOne(y => y.Question)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<AnswerEntity>(entity =>
            {
                entity.Property(x => x.Value).IsRequired(true);
                entity.Property(x => x.IsCorrect).IsRequired(true);

                entity
                    .HasOne(x => x.Question)
                    .WithMany(y => y.Answers)
                    .HasForeignKey(x => x.QuestionId);
            });
            
            builder.Entity<ClassEntity>(entity =>
            {
                entity.Property(x => x.Name).IsRequired(true);
            });

            builder.Entity<OrganizationEntity>(entity =>
            {
                entity.Property(x => x.Name).IsRequired(true);
                entity.Property(x => x.Type).IsRequired(true);
                entity
                    .HasMany(x => x.Users)
                    .WithOne(y => y.Organization)
                    .IsRequired(false);
            });

            builder.Entity<ProgressEntity>(entity =>
            {
                entity.Property(x => x.Score).HasDefaultValue(0);
                entity.Property(x => x.ManuallyChecked).HasDefaultValue(false);
                
                entity
                    .HasOne(x => x.Lesson)
                    .WithMany(y => y.Progresses)
                    .HasForeignKey(x => x.LessonId);

                entity
                    .HasOne(x => x.User)
                    .WithMany(y => y.Progresses)
                    .HasForeignKey(x => x.UserId);

                entity
                    .HasOne(x => x.Lesson)
                    .WithMany(y => y.Progresses)
                    .HasForeignKey(x => x.LessonId);

                entity
                    .HasOne(x => x.Course)
                    .WithMany(y => y.Progresses)
                    .HasForeignKey(x => x.CourseId);
            });

            builder.Entity<CommentEntity>(entity =>
            {
                entity
                    .HasMany(x => x.UsersLikes)
                    .WithOne(y => y.Comment);

                entity
                    .HasMany(x => x.Replies)
                    .WithOne(y => y.RootComment)
                    .HasForeignKey(x => x.RootCommentId)
                    .IsRequired(false);

                entity
                    .HasOne(x => x.Author)
                    .WithMany(y => y.Comments)
                    .HasForeignKey(x => x.AuthorId);

                entity
                    .HasOne(x => x.Lesson)
                    .WithMany(y => y.Comments)
                    .HasForeignKey(x => x.LessonId)
                    .IsRequired(false);
            });

            builder.Entity<AchievementEntity>(entity =>
            {
                entity
                    .HasMany(x => x.AchievementOwners)
                    .WithOne(y => y.Achievement)
                    .IsRequired(false);
            });
        }
    }
}