namespace Domain.Entity.Intermediate
{
    public class UserCommentLikesEntity
    {
        public string UserId { get; set; }
        public long CommentId { get; set; }

        public UserEntity User { get; set; }
        public CommentEntity Comment { get; set; }
    }
}