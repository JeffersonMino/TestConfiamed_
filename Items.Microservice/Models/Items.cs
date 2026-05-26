namespace Items.Microservice.Models
{
    public class Items
    {
        public class Item
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public string Description { get; set; }

            public string AssignedUser { get; set; }

            public DateTime DueDate { get; set; }

            public Relevance Relevance { get; set; }

            public Status Status { get; set; }

            public DateTime CreatedAt { get; set; }
        }
    }


}
