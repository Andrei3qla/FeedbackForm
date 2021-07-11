namespace FeedbackForm.ViewModels
{
    public class FeedbackRequest
    {
        public int UserDataId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int SubjectId { get; set; }
        public string Message { get; set; }
    }
    
}
