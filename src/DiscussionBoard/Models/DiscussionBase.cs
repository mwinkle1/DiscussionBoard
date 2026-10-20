namespace DiscussionBoard.Models
{
    public class DiscussionBase : EntityBase
    {
        private string Title;
        private string Content;
        private DateTimeOffset CreatedAt;
        private string ApplicationUserId;
        private ApplicationUser ApplicationUser;
    }
}
