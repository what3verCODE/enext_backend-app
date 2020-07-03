using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Abstract;
using Domain.Entity;
using Domain.Entity.Common;
using Domain.Entity.Intermediate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.Infrastructure.Persistence
{
    public class ApiDataContext : IdentityDbContext<UserEntity>
    {
        private readonly ICurrentUserService _currentUser;
        public ApiDataContext(DbContextOptions options, ICurrentUserService currentUser) : base(options)
        {
            _currentUser = currentUser;
        }
        public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
        public DbSet<OrganizationEntity> OrganizationEntity { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<ModuleEntity> Modules { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<LessonSectionEntity> Sections { get; set; }
        public DbSet<QuizEntity> Quizzes { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<UserCourseEntity> Subscriptions { get; set; }
        public DbSet<ProgressEntity> Progresses { get; set; }
        public DbSet<LastVisitedLessonEntity> LastVisitedLessons { get; set; }
        public DbSet<UserCourseLikesEntity> CoursesLikes { get; set; }
        public DbSet<UserLessonLikesEntity> LessonsLikes { get; set; }
        public DbSet<QuizAttempts> UserQuizAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureIntermediate();
            modelBuilder.Configure();
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.LastModifiedBy = _currentUser.UserId;
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUser.UserId;
                        entry.Entity.LastModifiedAt = DateTime.Now;
                        break;
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}