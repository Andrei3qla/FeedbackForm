namespace FeedbackForm.ViewModels
{
    public class FeedbackResponse
    {
        public FeedbackResponse(int userId, int messageId, string userPhone, string userEmail, string subject, string message)
        {
            UserId = userId;
            UserPhone = userPhone;
            UserEmail = userEmail;
            Subject = subject;
            Message = message;
            MessageId = messageId;
        }

        public int UserId { get; set; }
        public int MessageId { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}