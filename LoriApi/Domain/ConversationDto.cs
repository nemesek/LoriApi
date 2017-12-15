namespace LoriApi.Domain
{
    public class ConversationDto
    {
        public Sentences SentenceId { get; set; }
        public string Name { get; set; }
        public string UserResponse { get; set; }
        public string DisplayText { get; set; }
        public int Language { get; set; }
        public bool IsAssertion { get; set; }

    }
}
