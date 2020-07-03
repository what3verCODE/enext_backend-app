using System.Collections.Generic;
using Domain.Entity.Intermediate;
using Microsoft.AspNetCore.Identity;
namespace Domain.Entity
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Avatar { get; set; }
        public int? OrganizationId { get; set; }

        public virtual ICollection<UserCourseEntity> Subscriptions { get; set; }
        public virtual ICollection<UserAchievementsEntity> Achievements { get; set; }
        public virtual ICollection<ProgressEntity> Progresses { get; set; }
        public virtual ICollection<AuthorCourseEntity> CreatedCourses { get; set; }
        public virtual ICollection<CommentEntity> Comments { get; set; }

        public virtual ICollection<TeacherClassEntity> ClassesAsTeacher { get; set; }
        public virtual ICollection<StudentClassEntity> ClassesAsStudent { get; set; }

        public virtual ICollection<UserCourseLikesEntity> LikedCourses { get; set; }
        public virtual ICollection<UserLessonLikesEntity> LikedLessons { get; set; }
        public virtual ICollection<UserCommentLikesEntity> LikedComments { get; set; }
        public virtual ICollection<QuizAttempts> QuizAttempts { get; set; }
        public OrganizationEntity? Organization { get; set; }
    }
}