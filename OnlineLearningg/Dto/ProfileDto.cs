namespace OnlineLearningg.Dto
{
    public class ProfileDto
    {
        public int ProfileId { get; set; }

        public string Password { get; set; } = null!;

        public int Role { get; set; }

        public string Image { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }
    }
}
