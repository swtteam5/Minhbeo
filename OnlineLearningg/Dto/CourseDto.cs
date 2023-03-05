namespace OnlineLearningg.Dto
{
    public class CourseDto
    {
        public int Course_ID { get; set; }

        public int UserId { get; set; }

        public string CourseName { get; set; } = null!;

        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
