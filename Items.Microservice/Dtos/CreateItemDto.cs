namespace Items.Microservice.Dtos
{
    public class CreateItemDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int Relevance { get; set; }
    }
}
