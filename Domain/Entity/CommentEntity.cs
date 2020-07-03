using System;
using System.Collections.Generic;
using Domain.Entity.Intermediate;

namespace Domain.Entity
{
    public class CommentEntity
    {
        public long Id { get; set; }
        public string AuthorId { get; set; }
        public long? RootCommentId { get; set; }
        public long LessonId { get; set; }
        public string Text { get; set; }
        public DateTime WrittenAt { get; set; }
        public long Likes { get; set; }

        public virtual ICollection<CommentEntity> Replies { get; set; }

        public virtual ICollection<UserCommentLikesEntity> UsersLikes { get; set; }

        public CommentEntity RootComment { get; set; }
        public UserEntity Author { get; set; }
        public LessonEntity Lesson { get; set; }
    }
}